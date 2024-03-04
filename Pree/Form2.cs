using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pree
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string fileName = string.Format("{0}/databases/{1}", AppDomain.CurrentDomain.BaseDirectory, "NewUser.txt");

            StreamReader sr = new StreamReader(fileName);
            string line = string.Empty;
            try
            {
                line = sr.ReadLine();
                while (line != null)
                {
                    this.listBox1.Items.Add(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch
            {
                sr.Close();
            }
        }


        private void Save_Click(object sender, EventArgs e)
        {
            save();
        }

        public void save()
        {

    
            //chrome process id
            //time to wait until open chrome
            //var TimeToWait = TimeSpan.FromMinutes(TimeToWaitInMinutes);


            foreach (var item in listBox1.Items)
            {
                int ProcessId = -1;

                ChromeOptions options = null;
                ChromeDriver driver = null;

                ChromeDriverService cService =ChromeDriverService.CreateDefaultService();
                cService.HideCommandPromptWindow = true;
                options = new ChromeOptions();


                driver = new ChromeDriver(cService, options);
                driver.Navigate().GoToUrl("https://presearch.com/signup?rid=4782155");

                driver.FindElement(By.XPath(@"//*[@id=""main""]/div[1]/div[2]/div/a")).Click();

                driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[2]/div[1]/form/div[1]/input")).SendKeys(item + "@darolife.ir");

                Random rnd = new Random();
                int A = rnd.Next(9999999, 1000000000);
                string pass = "#$@%DSS#$" + A.ToString() + "!@$!@EAS#";


                driver.FindElement(By.XPath(@"/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[2]/div[1]/form/div[2]/input")).SendKeys(pass);
                driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[2]/div[1]/form/div[3]/input")).SendKeys(pass);

                driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[2]/div[1]/form/div[4]/label/input")).Click();

                string fileName = string.Format("{0}/databases/{1}", AppDomain.CurrentDomain.BaseDirectory, "db.txt");
                File.AppendAllText(fileName, item + "@darolife.ir" + " " + pass+"\r");

                while (true)
                {
                    if (driver.Url == "https://account.presearch.com/")
                    {
                        driver.Close();
                        driver.Quit();
                        driver.Dispose();
                        break;
                    }
                }
            }
        }






 
    }
}
