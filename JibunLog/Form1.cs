using System;
using System.IO;
using System.Windows.Forms;

namespace JibunLog
{
    /// <summary>
    /// メイン画面フォームクラス
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            ShowLog();
        }

        /// <summary>
        /// 書き込みボタンクリック時処理
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            // 入力内容をトリムする。
            txtInput.Text = txtInput.Text.Trim();

            // 入力内容が空でない場合は以下の処理を実行する。
            if (txtInput.Text != "" )
            {
                // 入力内容を渡してWriteメソッドを呼び出し、戻り値がtrueであれば以下の処理を実行する。
                if (Write(txtInput.Text))
                {
                    // 入力欄をクリアする。
                    txtInput.Clear();

                    // ShowLogメソッドを呼び出す。
                    ShowLog();
                }
            }
        }

        /// <summary>
        /// カレントフォルダのパスを取得します。
        /// </summary>
        /// <returns>カレントフォルダのパス</returns>
        private string GetFolder()
        {
            return Environment.CurrentDirectory;
        }

        /// <summary>
        /// ログ出力パスを取得します。
        /// </summary>
        /// <returns>ログ出力パス</returns>
        private string GetLogFilePath()
        {
            return string.Format("{0}\\{1}\\{2}.txt", GetFolder(), DateTime.Today.ToString("yyyy"), DateTime.Today.ToString("yyyyMM"));
        }

        /// <summary>
        /// ヘッダ文字列を取得します。
        /// </summary>
        /// <returns>ヘッダ文字列</returns>
        private String GetHeader()
        {
            return string.Format("[{0}] ", DateTime.Now.ToString("MM/dd HH:mm:ss"));
        }

        /// <summary>
        /// ログを書き込みます。
        /// </summary>
        /// <param name="text">ログ文字列</param>
        /// <returns>処理結果</returns>
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

        /// <summary>
        /// ログを表示します。
        /// </summary>
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
