namespace Impersonator.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class UserCollection : ConfigurationElementCollection
    {
        public UserElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as UserElement;
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

        public new UserElement this[string responseString]
        {
            get { return (UserElement)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        public void Add(UserElement user)
        {
            BaseAdd(user);
        }

        public void Remove(UserElement user)
        {
            BaseRemove(user);
        }

        public void EmptyCollection()
        {
            foreach(var e in this)
            {
                base.BaseRemoveAt(0);
            }
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new UserElement();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((UserElement)element).Name;
        }

        public override bool IsReadOnly()
        {
            return false;
        }
    }
}
