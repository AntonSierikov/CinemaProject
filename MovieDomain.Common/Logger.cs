using System;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using MovieDomain.Common.Constans;
using log4net;
using log4net.Repository;

namespace MovieDomain.Common
{
    public static class Logger
    {
        private static ILog _logger = null;

        public const string LOG4NET = "log4net";

        public const string NAME = "logger";

        public const string LOG_FILE = "LogFile";

        public const string LOG_FILE_REGEX = @"(\s*)CinemaProject(\s*)";

        //----------------------------------------------------------------//

        public static ILog Log
        {
            get
            {
                return _logger;
            }
        }

        //----------------------------------------------------------------//

        static Logger()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(LOG4NET + FileExtensions.CONFIG));
            ILoggerRepository repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                       typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig[LOG4NET]);
            _logger = LogManager.GetLogger(repo.Name, NAME);
        }

        //----------------------------------------------------------------//


    }
}
