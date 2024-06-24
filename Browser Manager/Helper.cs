using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Drawing;
using System.Windows.Forms;

namespace Browser_Manager
{
    internal class Helper
    {


        public static void log(string message)
        {
            File.AppendAllText("debug.txt", ("\n" + message + "\n\n=============================================================="));
        }
        public static void save_db()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            File.WriteAllText("DB.json", JsonConvert.SerializeObject(DataManager.profiles, settings));
        }
        public static string CalculateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
