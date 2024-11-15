using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Data
{
    internal class EnvConfig
    {
        public static readonly string server = ConfigurationManager.AppSettings["Server"];
        public static readonly string database = ConfigurationManager.AppSettings["Database"];
        public static readonly string userId = ConfigurationManager.AppSettings["User ID"];
        public static readonly string password = ConfigurationManager.AppSettings["Password"];
        public static readonly string emailHost = ConfigurationManager.AppSettings["EmailHost"];
        public static readonly string emailPort = ConfigurationManager.AppSettings["EmailPort"];
        public static readonly string emailDomain = ConfigurationManager.AppSettings["EmailDomain"];
        public static readonly string emailPassword = ConfigurationManager.AppSettings["EmailPassword"];
        public static readonly string cloudinaryCloud = ConfigurationManager.AppSettings["CloudinaryCloud"];
        public static readonly string cloudinaryKey = ConfigurationManager.AppSettings["CloudinaryKey"];
        public static readonly string cloudinarySecret = ConfigurationManager.AppSettings["CloudinarySecret"];
    }
}
