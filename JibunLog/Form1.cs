using System;
using System.IO;
using System.Windows.Forms;

namespace JibunLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ShowLog();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            txtInput.Text = txtInput.Text.Trim();
            if (txtInput.Text != "" )
            {
                if (Write(txtInput.Text))
                {
                    txtInput.Clear();
                    ShowLog();
                }
            }
        }

        private string GetFolder()
        {
            return Environment.CurrentDirectory;
        }

        private string GetLogFilePath()
        {
            return string.Format("{0}\\{1}\\{2}.txt", GetFolder(), DateTime.Today.ToString("yyyy"), DateTime.Today.ToString("yyyyMM"));
        }

        private String GetHeader()
        {
            return string.Format("[{0}] ", DateTime.Now.ToString("MM/dd HH:mm:ss"));
        }

        private bool Write(string text)
        {
            bool result = false;

            try
            {
                string filePath = GetLogFilePath();
                string folderPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(GetHeader());
                    sw.WriteLine(text);
                    sw.WriteLine();
                }

                result = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        private void ShowLog()
        {
            string filePath = GetLogFilePath();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        txtViewer.Text = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
