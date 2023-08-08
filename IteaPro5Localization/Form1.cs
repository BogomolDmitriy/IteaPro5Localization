using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IteaPro5Localization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UkrainianMenuItem_Click(object sender, EventArgs e)
        {
            UkrainianMenuItem.Checked = true;
            englishMenuItem.Checked = false;
        }

        private void englishMenuItem_Click(object sender, EventArgs e)
        {
            UkrainianMenuItem.Checked = false;
            englishMenuItem.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FormLocalization ua = new FormLocalization()
            //{
            //    fileMenuItem = "Фаіл",
            //    openMenuItem = "Відкрити"
            //};

            //SaveLocale(ua, "ua.txt");

            FormLocalization ua = LoadFromFile("ua.txt");

            FormLocalization en = new FormLocalization()
            {
                fileMenuItem = "File",
                openMenuItem = "Open"
            };

            FormLocalization current = null;
            if (englishMenuItem.Checked)
            {
                current = en;
            }

            else if (UkrainianMenuItem.Checked)
            {
                current = ua;
            }

            LocationLoad(current);
        }

        private FormLocalization LoadFromFile(string failName)
        {
            using (StreamReader streamReader = new StreamReader(failName))
            {
                string readFile = streamReader.ReadToEnd();
                return JsonSerializer.Deserialize<FormLocalization>(readFile);
            }
        }

        private void LocationLoad(FormLocalization current)
        {
            fileMenuItem.Text = current.fileMenuItem;
            openMenuItem.Text = current.openMenuItem;
        }

        private void SaveLocale(FormLocalization Locale, string fileName)
        {
            string uaLocale = JsonSerializer.Serialize(Locale);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.WriteLine(uaLocale);
            }
        }
    }
}
