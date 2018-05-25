namespace Impersonator.Configuration
{
    using System.Configuration;

    internal class UserElement : ConfigurationElement
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
        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get
            {
                return this["password"] as string;
            }
            set
            {
                this["password"] = value;
            }
        }
        [ConfigurationProperty("domain", IsRequired = true)]
        public string Domain
        {
            get
            {
                return this["domain"] as string;
            }
            set
            {
                this["domain"] = value;
            }
        }
    }
}
