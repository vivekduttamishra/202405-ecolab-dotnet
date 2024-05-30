using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementConsole01
{
    public  class AppSettings
    {
        public static AppSettings I { get;private set; }=new AppSettings();
        private IConfiguration config;

        public AppSettings()
        {
            config=new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public T Get<T>(string key, T defaultValue=default(T))
        {
            try
            {
                return (T)Convert.ChangeType(config[key], typeof(T));
            }
            catch { 
                return defaultValue; 
            }
        }

        public string this[string key]
        {
            get
            {
                return Get<string>(key,"");
            }
        }
    }
}
