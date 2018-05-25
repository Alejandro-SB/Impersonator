namespace Impersonator.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ModuleElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("command", IsRequired = true)]
        public string Command
        {
            get
            {
                return this["command"] as string;
            }
            set
            {
                this["command"] = value;
            }
        }

        [ConfigurationProperty("args", IsRequired = true)]
        public string Arguments
        {
            get
            {
                return this["arguments"] as string;
            }
            set
            {
                this["arguments"] = value;
            }
        }
    }
}
