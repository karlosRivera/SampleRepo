using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CSRBusiness
{

    public class DBConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ItemsCollection Items
        {
            get
            {
                return ((ItemsCollection)(base[""]));
            }
        }
    }

    [ConfigurationCollection(typeof(ItemsElement))]
    public class ItemsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ItemsElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ItemsElement)(element)).CountryCode;
        }

        public ItemsElement this[int idx]
        {
            get
            {
                return (ItemsElement)BaseGet(idx);
            }
        }
    }

    public class ItemsElement : ConfigurationElement
    {
        [ConfigurationProperty("servername", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string ServerName
        {
            get
            {
                return ((string)(base["servername"]));
            }
            set
            {
                base["servername"] = value;
            }
        }

        [ConfigurationProperty("dbname", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string DBName
        {
            get
            {
                return ((string)(base["dbname"]));
            }
            set
            {
                base["dbname"] = value;
            }
        }

        [ConfigurationProperty("userid", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string UserID
        {
            get
            {
                return ((string)(base["userid"]));
            }
            set
            {
                base["userid"] = value;
            }
        }

        [ConfigurationProperty("password", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Password
        {
            get
            {
                return ((string)(base["password"]));
            }
            set
            {
                base["password"] = value;
            }
        }

        [ConfigurationProperty("countrycode", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string CountryCode
        {
            get
            {
                return ((string)(base["countrycode"]));
            }
            set
            {
                base["countrycode"] = value;
            }
        }
    }

}