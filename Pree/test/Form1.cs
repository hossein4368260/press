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
using System.Threading;
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
        public static Label lbl = new Label();
        public static string localAdddrese = @"E:\robat";
        public static string foldername;
        public string UsernameSite;
        public string PasswordSite;

        public static string word;
        public static DataGridView dataGridiew = new DataGridView();
        public static DataGridView dataword2 = new DataGridView();


        private void Form1_Load(object sender, EventArgs e)
        {
            //***** Load Data in DataGridView ***//
            loadgv();
            serchword();
            dataGridiew = dataGridView1;
            dataword2 = Dataword;



        }

        public void serchword()
        {
            string delimeter = "\t";
            string tableName = "BooksTable";
            //  string fileName = string.Format("{0}/databases/{1}", AppDomain.CurrentDomain.BaseDirectory, "bigtest.sql");
            string fileName = string.Format("{0}/databases/{1}", AppDomain.CurrentDomain.BaseDirectory, "srch.txt");

            DataSet dataset = new DataSet();
            StreamReader sr = new StreamReader(fileName);

            dataset.Tables.Add(tableName);
            dataset.Tables[tableName].Columns.Add("id");
            dataset.Tables[tableName].Columns.Add("word");
            dataset.Tables[tableName].Columns.Add("cost");


            string allData = sr.ReadToEnd();
            string[] rows = allData.Split("\r".ToCharArray());

            foreach (string r in rows)
            {
                string[] items = r.Split(delimeter.ToCharArray());
                dataset.Tables[tableName].Rows.Add(items);
            }
            this.Dataword.DataSource = dataset.Tables[0].DefaultView;
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
            foreach (DataGridViewRow row in dataGridiew.Rows)
            {
                try
                {

                    if (Directory.Exists(localAdddrese) == false)
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



        public static IWebDriver loadChrome(string FolderPathToStoreSession)
        {
            ChromeOptions options = null;
            ChromeDriver driver = null;
            driver.Manage().Window.Minimize();
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

                Random rnd = new Random();
                word = dataword2.Rows[rnd.Next(0, dataword2.Rows.Count - 1)].Cells[1].Value.ToString();

                //   dataGridView1.Rows
                driver.Navigate().GoToUrl("https://presearch.com/search?q=" + word);



                //set process id of chrome
                ProcessId = cService.ProcessId;



                Thread.Sleep(5000);

                try
                {


                    lbl.Location = new Point(13, 13);
                    lbl.Text = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div[2]/div[1]/div[2]/div[5]/div[2]/div/div/div[1]/div[1]")).GetAttribute("value");


                }
                catch (Exception)
                {

                }


                driver.Close();
                driver.Quit();
                driver.Dispose();
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

            for (int i = 0; i < 250; i++)
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







        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string delimeter = "\t";
            string tableName = "BooksTable";
            //  string fileName = string.Format("{0}/databases/{1}", AppDomain.CurrentDomain.BaseDirectory, "bigtest.sql");
            string fileName = string.Format("{0}/databases/{1}", AppDomain.CurrentDomain.BaseDirectory, "Mail.txt");

            DataSet dataset = new DataSet();
            StreamReader sr = new StreamReader(fileName);

            dataset.Tables.Add(tableName);
            dataset.Tables[tableName].Columns.Add("Username");

            string allData = sr.ReadToEnd();
            string[] rows = allData.Split("\r".ToCharArray());

            foreach (string r in rows)
            {
                string[] items = r.Split(delimeter.ToCharArray());
                dataset.Tables[tableName].Rows.Add(items);
            }
            this.EnailC.DataSource = dataset.Tables[0].DefaultView;


     
            ChromeOptions options = null;
            ChromeDriver ds = null;
            ChromeDriverService cService =         ChromeDriverService.CreateDefaultService();
          cService.HideCommandPromptWindow = true;
            options = new ChromeOptions();
            ds = new ChromeDriver(cService, options);



            Random rnd = new Random();
            var q = rnd.Next(10000000, 900000000);

            ds.Navigate().GoToUrl("https://2193181509.cloudylink.com:3333/user/email/create-account");
            ds.FindElement(By.XPath(@"//*[@id=""username""]")).SendKeys("daroli");
            ds.FindElement(By.XPath("password")).SendKeys("x7n33d5or");

            ds.FindElement(By.XPath("/html/body/div[1]/section/div/div[1]/div[2]/button/span/span")).Click();

            DialogResult result = MessageBox.Show("Do you want to close this window?", "Close Window", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in EnailC.Rows)
                {
                  //  d.Navigate().GoToUrl("https://2193181509.cloudylink.com:3333/user/email/create-account");

                    ds.FindElement(By.XPath("/html/body/div[1]/div[1]/main/section/div/div[2]/div[2]/section/div[1]/div/div[1]/div/div/div[2]/input")).SendKeys(item.Cells["username"].Value.ToString());
                    ds.FindElement(By.XPath("/html/body/div[1]/div[1]/main/section/div/div[2]/div[2]/section/div[2]/div/div[1]/div/div/div/div[2]/input")).SendKeys(q.ToString());
                    ds.FindElement(By.XPath("/html/body/div[1]/div[1]/main/section/div/div[2]/div[2]/div/button")).Click();

                    WriteNotepad(item.Cells["username"].Value.ToString(), q.ToString());
                }
            }
            else
            {
            }



        }

        private void ChkUrl_Tick(object sender, EventArgs e)
        {


            lbl_cost.Text = lbl.Text;

        }

        private void Btn_load_Click(object sender, EventArgs e)
        {
            TimerSerch.Start();
        }

        // public Thread workerThread = new Thread(new ThreadStart(start));



        private void TimerSerch_Tick(object sender, EventArgs e)
        {

            start();



        }

        public void start()
        {
            for (int i = 0; i < 250; i++)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridiew.Rows)
                    {
                        if (row.Cells["username"].Value.ToString() != null)
                        {
                            foldername = row.Cells["username"].Value.ToString().Replace("@darolife.ir", "");
                            loadChrome(@localAdddrese + "/" + foldername);
                        }
                    }
                }
                catch { };
            }
        }



        public  void WriteNotepad(string User, string password)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(User + " " + password);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}
