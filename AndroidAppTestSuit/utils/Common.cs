using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AndroidAppTestSuit.utils
{
    class Common
    {
        private static string testEnv;

        public static void Pause(int ms)
        {
            Thread.Sleep(ms);
        }

        public static String GenerateRandomValue()
        {
            return "-" + RandomStringUtils.RandomStringUtils.RandomAlphabetic(3).ToLower();
        }

        public static String GetTestEnv()
        {
            return testEnv;
        }

        public static Boolean IsShould(string condition)
        {
            if (condition.Equals("should"))
            {
                return true;
            }
            else if (condition.Equals("should not"))
            {
                return false;
            }
            else
            {
                throw new ArgumentException(String.Format("'{0}' - unsupported condition", condition));
            }
        }

        public static string GetConfigValue(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                throw new Exception("Error reading app settings");
            }
        }

        public static string GetFilePathForRunViaSpecrun(string directory)
        {
            string resultString = "";
            if (directory.Contains("bin"))
            {
                Regex rgx = new Regex("(bin)(.)+");
                resultString = rgx.Replace(directory, "");
                return resultString;
            }
            else
            {
                return directory;
            }
        }

        public static string GetSignOfScroll(string direction)
        {
            string directionSign = "";
            if (direction.Equals("up"))
            {
                directionSign = "";
            }
            else if (direction.Equals("down"))
            {
                directionSign = "-";
            }
            else
            {
                throw new Exception(string.Format("'{0}' - unsupported direction", direction));
            }
            return directionSign;
        }

        public static string GetProjectRootDir()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).FullName
                   + Path.DirectorySeparatorChar
                   + Common.GetConfigValue("projectName");
        }

        public static string IsTextShadowed(string css)
        {
            if (css.Equals("none"))
            {
                return "false";
            }
            else
            {
                return "true";
            }
        }
    }
}
