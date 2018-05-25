namespace Impersonator.Configuration
{
    using System.Configuration;

    internal class UserSection : ConfigurationSection
    {
        public static UserSection GetUserSection()
        {
            var cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return (UserSection)cfg.GetSection("Users") ?? new UserSection();
        }

        [System.Configuration.ConfigurationProperty("Users")]
        [ConfigurationCollection(typeof(UserElement), AddItemName = "User")]
        public UserCollection Users
        {
            get
            {
                var users = this["Users"];
                return users as UserCollection;
            }
        }

        public override bool IsReadOnly()
        {
            return false;
        }
    }
}