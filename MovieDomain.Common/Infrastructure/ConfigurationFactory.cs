using System.IO;
using Microsoft.Extensions.Configuration;

namespace MovieDomain.Common.Infrastructure
{
    public class ConfigurationFactory
    {
        public IConfiguration configuration { get; private set; }

        //----------------------------------------------------------------//

        public ConfigurationFactory(string folderName, string fileName)
        {

            ConfigurationBuilder builder = new ConfigurationBuilder();
            if (Directory.Exists(folderName))
            {
                configuration = builder.SetBasePath(folderName)
                                       .AddJsonFile(fileName) 
                                       .Build();
            }
        }


        //----------------------------------------------------------------//

        public string GetSettingValue(string key)
        {
            return configuration[key];
        }

        //----------------------------------------------------------------//
            
        public string GetConnectionString(string key)
        {
            return configuration.GetConnectionString(key);
        }
    }
}
