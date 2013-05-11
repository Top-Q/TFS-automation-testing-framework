using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;

namespace TestProject
{
    // Define a custom section. This class is used to
    // populate the configuration file.
    // It creates the following custom section:
    //  <CustomSection name="Contoso" url="http://www.contoso.com" port="8080" />.
    public sealed class CustomSection : ConfigurationSection
    {

        public CustomSection()
        {

        }


        [ConfigurationProperty("name",
     DefaultValue = "Contoso",
     IsRequired = true,
     IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }


        [ConfigurationProperty("port",
       DefaultValue = (int)8080,
       IsRequired = false)]
        [IntegerValidator(MinValue = 0,
            MaxValue = 8080, ExcludeRange = false)]
        public int Port
        {
            get
            {
                return (int)this["port"];
            }
            set
            {
                this["port"] = value;
            }
        }




        public object[] Url { get; set; }
    }
}
