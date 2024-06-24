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
using Browser_Manager.Properties;
using OpenQA.Selenium.DevTools.V115.Emulation;
using OpenQA.Selenium.DevTools.V115.Network;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Browser_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateFlowPanel(sender, e);
        }

        private void Button_Profile_ADD_Click(object sender, EventArgs e)
        {
            DataManager.Profile profile = new DataManager.Profile();
            //foreach (Control c in panelCONTROLS.Controls)
            //{
            //    if(c.Text == "" || c.Text == null)
            //    {
            //        return;
            //    }
            //}
            //if (textBox_Profile_NAME.Text == "" || textBox_Profile_NAME.Text == null)
            //{
            //    return;
            //}
            if (DataManager.profiles.Exists(x => x.ID == textBox_Profile_NAME.Text))
            {
                profile = DataManager.profiles.FirstOrDefault(x => x.ID == textBox_Profile_NAME.Text);
            }
            else
            {
                profile.ID = textBox_Profile_NAME.Text;
            }
            //profile.Surename = textBox_Surename.Text;
            //profile.Name = textBox_Name.Text;
            //profile.Email = textBox_Email.Text;
            //profile.Password = textBox_Password.Text;
            //profile.Address.Street = textBox_Street.Text;
            //profile.Address.Number = textBox_Number.Text;
            //profile.Address.City = textBox_City.Text;
            //profile.Address.Zip = textBox_ZIP.Text;
            //profile.Address.Country = textBox_Country.Text;
            profile.Proxy = textBox_Proxy.Text;
            

            //profile.Releases = new List<DataManager.Release>();

            if (!DataManager.profiles.Exists(x => x.ID == textBox_Profile_NAME.Text))
            {
                DataManager.profiles.Add(profile);
            }
            
            string dir = Directory.GetCurrentDirectory() + @"\Profiles\" + Helper.CalculateMD5(profile.ID) + @"\Chrome";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string dir2 = Directory.GetCurrentDirectory() + @"\Profiles\" + Helper.CalculateMD5(profile.ID) + @"\MUSIC";
            if (!Directory.Exists(dir2))
            {
                Directory.CreateDirectory(dir2);
            }
            File.WriteAllText((dir + @"\profile.json"), JsonConvert.SerializeObject(profile));
            Helper.save_db();

            updateFlowPanel(sender, e);
        }

        private void button_Artist_ADD_Click(object sender, EventArgs e)
        {
            
        }

        private void label_Surename_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if(label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Name_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Email_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Password_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Proxy_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Street_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Number_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_City_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_ZIP_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Country_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Artist_Name_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Artist_ID_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (label.Text != "" && label.Text != null)
            {
                Clipboard.SetText(label.Text);
            }
        }

        private void label_Artists_Click(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.SelectedItem.ToString() != "" && box.SelectedItem.ToString() != null)
            {
                Process.Start(new System.Diagnostics.ProcessStartInfo(("spotify:artist:" + box.SelectedItem.ToString())) { UseShellExecute = true });
            }
        }

        public void updateFlowPanel(object sender, EventArgs e)
        {
            FlowProfiles .Controls.Clear();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            string[] dirs = Directory.GetDirectories(@"Profiles", "*", SearchOption.TopDirectoryOnly);

            foreach (string profile_folder in dirs)
            {
                DataManager.Profile profile = JsonConvert.DeserializeObject<DataManager.Profile>(File.ReadAllText(profile_folder + @"\Chrome\profile.json"), settings);
                DataManager.profiles.Add(profile);

                Panel PanelProfile = new Panel()
                {
                    Name = profile.ID,
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                    Size = new System.Drawing.Size(490, 100),
                    TabIndex = 1,
                };
                Label LabelProfile = new Label
                {
                    Size = new Size(250, 50),
                    Location = new Point(25, 23),
                    Text = profile.ID,
                    ForeColor = Color.Green,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                Button ButtonOpen = new Button
                {
                    Size = new Size(75, 50),
                    Location = new Point(400, 23),
                    Text = "Start",
                    ForeColor = Color.YellowGreen,
                    Font = new Font("Arial", 15, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                ButtonOpen.Click += new EventHandler((senderr, ee) => EventHelper.start_Profile(senderr, ee, profile));
                PanelProfile.Click += new EventHandler((senderr, ee) => EventHelper.select_Profile(senderr, ee, profile, PanelProfile));

                PanelProfile.Controls.Add(LabelProfile);
                PanelProfile.Controls.Add(ButtonOpen);

                FlowProfiles.Controls.Add(PanelProfile);
                DataManager.profiles.Add(profile);
            }
        }
    }
}
