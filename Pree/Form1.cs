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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string localAdddrese = @"E:\robat";
        public string foldername;
        public string UsernameSite;
        public string PasswordSite;

        public string word;
        private void Form1_Load(object sender, EventArgs e)
        {
            //***** Load Data in DataGridView ***//
            loadgv();



        }


        public void loadgv()
        {
            string delimeter = "\t";
            string tableName = "BooksTable";
            //  string fileName = string.Format("{0}/databases/{1}", AppDomain.CurrentDomain.BaseDirectory, "bigtest.sql");
            string fileName = string.Format("{0}/databases/{1}", AppDomain.CurrentDomain.BaseDirectory, "user.txt");

            DataSet dataset = new DataSet();
            StreamReader sr = new StreamReader(fileName);

            dataset.Tables.Add(tableName);
            dataset.Tables[tableName].Columns.Add("id");
            dataset.Tables[tableName].Columns.Add("Username");
            dataset.Tables[tableName].Columns.Add("password");


            string allData = sr.ReadToEnd();
            string[] rows = allData.Split("\r".ToCharArray());

            foreach (string r in rows)
            {
                string[] items = r.Split(delimeter.ToCharArray());
                dataset.Tables[tableName].Rows.Add(items);
            }
            this.dataGridView1.DataSource = dataset.Tables[0].DefaultView;
        }

        private void Btn_crtfolder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
 
                    if (Directory.Exists(localAdddrese)==false)
                    {
                        //create Root Folder
                        Directory.CreateDirectory(localAdddrese);
                       MessageBox.Show(row.Cells["username"].Value.ToString().Replace("@darolife.ir", ""));
                    }
                    
                    //Create Sub Folder
                    if (Directory.Exists(@localAdddrese + "/" + row.Cells["username"].Value.ToString().Replace("@darolife.ir", "")) == false)
                    {
                        Directory.CreateDirectory(@localAdddrese + "/" + row.Cells["username"].Value.ToString().Replace("@darolife.ir", ""));
                    }

                }
                catch (Exception)
                {
                }


            }

        }













        public IWebDriver Savechrome(string FolderPathToStoreSession)
        {
            ChromeOptions options = null;
            ChromeDriver driver = null;
            try
            {
                //chrome process id
                int ProcessId = -1;
                //time to wait until open chrome
                //var TimeToWait = TimeSpan.FromMinutes(TimeToWaitInMinutes);
                ChromeDriverService cService =
                ChromeDriverService.CreateDefaultService();
                //hide dos screen
                cService.HideCommandPromptWindow = true;
                options = new ChromeOptions();
                //options.AddArguments("chrome.switches", "--disable-extensions");

                //session file directory
                options.AddArgument("--user-data-dir=" + FolderPathToStoreSession);
                driver = new ChromeDriver(cService, options);

               

                //try
                //{
                //    foreach (DataGridViewRow row in dataGridView1.Rows)
                //    {
                        driver.Navigate().GoToUrl("https://account.presearch.com/login");
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[1]/form/div[1]/input")).SendKeys(UsernameSite);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[1]/form/div[2]/div/input")).SendKeys(PasswordSite);
                        driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[1]/form/div[3]/div[1]/div[1]/div/label/input")).Click();
                        MessageBox.Show("continue ?");
                        //set process id of chrome
          
                //    }
                //}
                //catch
                //{ }














                    //set process id of chrome
                    ProcessId = cService.ProcessId;

                return driver;
            }
            catch (Exception ex)
            {
                if (driver != null)
                {
                    driver.Close();
                    driver.Quit();
                    driver.Dispose();
                }
                driver = null;
                throw ex;
            }
        }

        public IWebDriver loadChrome(string FolderPathToStoreSession)
        {
            ChromeOptions options = null;
            ChromeDriver driver = null;
            try
            {
                //chrome process id
                int ProcessId = -1;
                //time to wait until open chrome
                //var TimeToWait = TimeSpan.FromMinutes(TimeToWaitInMinutes);
                ChromeDriverService cService = ChromeDriverService.CreateDefaultService();

                //hide dos screen
                cService.HideCommandPromptWindow = true;

                options = new ChromeOptions();

                //session file directory
                options.AddArgument("--user-data-dir=" + FolderPathToStoreSession);
                //options.AddArgument("--no-sandbox");

                //options.AddArgument("--headless=new");

                //Add EditThisCookie Extension
                //options.AddArguments("chrome.switches", "--disable-extensions");
                //options.AddExtensions("\\ChromeExtensions\\editthiscookie.crx");

                driver = new ChromeDriver(cService, options);



                driver.Navigate().GoToUrl("https://presearch.com/search?q="+word);

                MessageBox.Show("load Finish");

                //set process id of chrome
                ProcessId = cService.ProcessId;

                return driver;
            }
            catch (Exception ex)
            {
                if (driver != null)
                {
                    driver.Close();
                    driver.Quit();
                    driver.Dispose();
                }
                driver = null;
                throw ex;
            }
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells["username"].Value.ToString() != null)
                {
                    foldername = row.Cells["username"].Value.ToString().Replace("@darolife.ir", "");
                    UsernameSite = row.Cells["username"].Value.ToString();
                    PasswordSite = row.Cells["password"].Value.ToString();

                    Savechrome(@localAdddrese + "/" + foldername);
                }
   
            }


 

            


        }

        private void Button1_Click(object sender, EventArgs e)
        {
                /*
            ChromeDriver d = new ChromeDriver();
            d.Navigate().GoToUrl("https://account.presearch.com/login");
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    d.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[1]/form/div[1]/input")).SendKeys(row.Cells["username"].Value.ToString());
                    d.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[1]/form/div[2]/div/input")).SendKeys(row.Cells["password"].Value.ToString());
                    d.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[3]/div[1]/form/div[3]/div[1]/div[1]/div/label/input")).Click();
                    MessageBox.Show("continue ?");
                }
            }
            catch
            {

            }
            */
 


        }

        private void ChkUrl_Tick(object sender, EventArgs e)
        {
       // https://account.presearch.com/tokens/usage-rewards
        }

        private void Btn_load_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells["username"].Value.ToString() != null)
                {
                    foldername = row.Cells["username"].Value.ToString().Replace("@darolife.ir", "");
                    loadChrome(@localAdddrese + "/" + foldername);
                }

            }
        }
    }
}
