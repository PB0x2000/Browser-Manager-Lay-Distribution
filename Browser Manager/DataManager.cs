using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;

namespace Browser_Manager
{
    internal class DataManager
    {
        public static List<Profile> profiles = new List<Profile>();
        public static Current current = null;

        public class Current
        {
            public Profile profile { get; set; }
            public Panel panel { get; set; }
        }
        public class Profile
        {
            public string ID { get; set; }
            public string Surename { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public Address Address { get; set; }
            public string Proxy { get; set; }
            public ChromeDriver Driver { get; set; }
            public List<Release> Releases { get; set; }
        }
        public class Artist
        {
            public string Name { get; set; }
            public string ID { get; set; }
        }
        public class Release
        {
            public string Name { get; set; }
            public string AID { get; set; }
            public string TID { get; set; }
            public string UPC { get; set; }
            public string ISRC { get; set; }
            public string Genre { get; set; }
            public string Date { get; set; }
            public List<Artist> Artists { get; set; }
        }
        public class Address
        {
            public string Street { get; set; }
            public string Number { get; set; }
            public string City { get; set; }
            public string Zip { get; set; }
            public string Country { get; set; }
        }
    }
}
