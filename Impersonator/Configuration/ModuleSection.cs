namespace Impersonator.Configuration
{
    using System.Configuration;

    internal class ModuleSection : ConfigurationSection
    {
        [System.Configuration.ConfigurationProperty("Modules")]
        [ConfigurationCollection(typeof(ModuleElement), AddItemName = "Module")]
        public ModuleCollection Modules
        {
            get
            {
                var modules = this["Modules"];
                return (ModuleCollection)modules;
            }
        }

        public override bool IsReadOnly()
        {
            return false;
        }
    }
}
