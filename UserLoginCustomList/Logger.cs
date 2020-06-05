using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginCustomList.Domain;

namespace UserLoginCustomList
{
    public static class Logger
    {
        private static List<string> CurrentSessionActivities = new List<string>();

        public static void LogActivity(string username, UserRole role, string activity)
        {
            string activityLine = DateTime.Now + ";"
                + username + ";"
                + role + ";"
                + activity;

            File.AppendAllText("test.txt", activityLine + Environment.NewLine);

            CurrentSessionActivities.Add(activityLine);
        }

        public static string ReadActivityLog()
        {
            StreamReader sr = new StreamReader("log.txt");

            string line;
            StringBuilder sb = new StringBuilder();
            while ((line = sr.ReadLine()) != null)
            {
                sb.Append(line + Environment.NewLine);
            }

            sr.Close();

            return sb.ToString();
        }

        public static string GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(Environment.NewLine, CurrentSessionActivities);

            return sb.ToString();
        }
    }
}
