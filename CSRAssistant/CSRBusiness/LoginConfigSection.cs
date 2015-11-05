using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CSRBusiness
{
    public class LoginConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public LoginCollection Items
        {
            get
            {
                return ((LoginCollection)(base[""]));
            }
        }
    }

    [ConfigurationCollection(typeof(LoginElement))]
    public class LoginCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LoginElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LoginElement)(element)).ID;
        }

        public LoginElement this[int idx]
        {
            get
            {
                return (LoginElement)BaseGet(idx);
            }
        }
    }
    public class LoginElement : ConfigurationElement
    {
        [ConfigurationProperty("UserName", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string UserName
        {
            get
            {
                return ((string)(base["UserName"]));
            }
            set
            {
                base["UserName"] = value;
            }
        }

        [ConfigurationProperty("Pwd", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Pwd
        {
            get
            {
                return ((string)(base["Pwd"]));
            }
            set
            {
                base["Pwd"] = value;
            }
        }

        [ConfigurationProperty("Country", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Country
        {
            get
            {
                return ((string)(base["Country"]));
            }
            set
            {
                base["Country"] = value;
            }
        }

        [ConfigurationProperty("ID", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string ID
        {
            get
            {
                return ((string)(base["ID"]));
            }
            set
            {
                base["ID"] = value;
            }
        }
    }
}
