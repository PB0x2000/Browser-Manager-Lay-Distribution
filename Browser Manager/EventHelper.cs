using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;

namespace Browser_Manager
{
    internal class EventHelper
    {
        public static void start_Profile(object sender, EventArgs e, DataManager.Profile profile)
        {
            Button b = (Button)sender;
            if(b.Text == "Start")
            {
                ChromeDriver driver = Selenium.start_chrome(profile, false);
                if (driver != null)
                {
                    profile.Driver = driver;
                    b.Text = "Stop";
                }
            }
            else
            {
                profile.Driver.Dispose();
                profile.Driver = null;
                b.Text = "Start";
            }
        }
        public static void select_Profile(object sender, EventArgs e, DataManager.Profile profile, Panel panel) 
        {
            if (DataManager.current != null)
            {
                DataManager.current.panel.BorderStyle = BorderStyle.FixedSingle;
                DataManager.current.panel.Padding = new Padding(1);
                DataManager.current.panel.BackColor = Color.Black;
            }
            DataManager.current = new DataManager.Current();
            DataManager.current.panel = panel;
            DataManager.current.profile = profile;
            DataManager.current.panel.BorderStyle = BorderStyle.FixedSingle;
            DataManager.current.panel.Padding = new Padding(3);
            DataManager.current.panel.BackColor = Color.DimGray;

            
        }
    }
}
