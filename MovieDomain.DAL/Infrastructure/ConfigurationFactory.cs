using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using MovieDomain.Constans;
using Microsoft.EntityFrameworkCore;

namespace MovieDomain.DAL.Infrastructure
{
    public static class ConfigurationFactory
    {
        public static IConfiguration configuration { get; private set; }

        //----------------------------------------------------------------//

        static ConfigurationFactory()
        {

            ConfigurationBuilder builder = new ConfigurationBuilder();
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            string directoryPath = Directory.GetCurrentDirectory();
            string path = appPathMatcher.Match(directoryPath).Value;

            if (Directory.Exists(path))
            {
                configuration = builder.SetBasePath(path)
                       .AddJsonFile(ConfigurationConstans.DefaultJsonSettingFileName)
                       .Build();
            }
        }

        //----------------------------------------------------------------//

        public static string MainDb
        {
            get { return configuration?.GetConnectionString(ConfigurationConstans.MainDb); }
        }

        //----------------------------------------------------------------//

    }
}
