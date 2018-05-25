namespace Impersonator.Configuration
{
    using Impersonator.Classes;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;

    public class ConfigurationHelper
    {
        private readonly Configuration _config;

        public ConfigurationHelper()
        {
            this._config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        internal BindingList<User> GetUsers()
        {
            var userElements = this._getUsersSection().Users;
            var users = new BindingList<User>();

            foreach (UserElement user in userElements)
            {
                users.Add(new User(user.Name, user.Domain, user.Password));
            }

            return users;
        }

        public BindingList<Module> GetModules()
        {
            var moduleElements = this._getModulesSection().Modules;
            var modules = new BindingList<Module>();

            foreach (ModuleElement mod in moduleElements)
            {
                modules.Add(new Module()
                {
                    Name = mod.Name,
                    Arguments = mod.Arguments,
                    Command = mod.Command
                });
            }

            return modules;
        }

        private UserSection _getUsersSection()
        {
            return (UserSection)this._config.GetSection("Users") ?? new UserSection();
        }

        private ModuleSection _getModulesSection()
        {
            return (ModuleSection)this._config.GetSection("Modules") ?? new ModuleSection();
        }


        internal void SaveConfiguration(IList<User> users, IList<Module> modules)
        {
            var userSection = this._getUsersSection();
            var moduleSection = this._getModulesSection();

            userSection.Users.EmptyCollection();
            moduleSection.Modules.EmptyCollection();

            foreach(var user in users)
            {
                userSection.Users.Add(new UserElement()
                {
                    Name = user.Name,
                    Domain = user.Domain,
                    Password = user.Password
                });
            }

            foreach(var module in modules)
            {
                moduleSection.Modules.Add(new ModuleElement()
                {
                    Name = module.Name,
                    Command = module.Command,
                    Arguments = module.Arguments
                });
            }


            userSection.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            userSection.SectionInformation.ForceSave = true;

            moduleSection.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
            moduleSection.SectionInformation.ForceSave = true;

            this._config.Save(ConfigurationSaveMode.Full);
        }
    }
}
