namespace Impersonator.Configuration
{
    using System.Configuration;

    internal class ModuleCollection : ConfigurationElementCollection
    {
        public ModuleElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as ModuleElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new ModuleElement this[string responseString]
        {
            get { return (ModuleElement)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        public void Add(ModuleElement user)
        {
            BaseAdd(user);
        }

        public void Remove(ModuleElement user)
        {
            BaseRemove(user);
        }

        public void EmptyCollection()
        {
            foreach (var e in this)
            {
                base.BaseRemoveAt(0);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ModuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ModuleElement)element).Name;
        }

        public override bool IsReadOnly()
        {
            return false;
        }
    }
}
