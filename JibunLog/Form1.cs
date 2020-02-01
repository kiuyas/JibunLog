using System;
using System.Diagnostics;
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
        }

        /// <summary>
        /// フォームロード時処理
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            string logFolderPath = LogFileManager.GetLogFolder();

            if (logFolderPath == null)
            {
                MessageBox.Show(this, "ログフォルダを作成できません。終了します。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }

            ShowLog();
        }

        /// <summary>
        /// 書き込みボタンクリック時処理
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                // 入力内容をトリムする。
                txtInput.Text = txtInput.Text.Trim();

                // 入力内容が空でない場合は以下の処理を実行する。
                if (txtInput.Text != "")
                {
                    // 入力内容を渡してWriteメソッドを呼び出し、戻り値がtrueであれば以下の処理を実行する。
                    LogFileManager.Write(txtInput.Text);

                    // 入力欄をクリアする。
                    txtInput.Clear();

                    // ShowLogメソッドを呼び出す。
                    ShowLog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// ログを表示します。
        /// </summary>
        private void ShowLog()
        {
            try
            {
                txtViewer.Text = LogFileManager.Read();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// 過去ログフォルダを表示します。
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnLogFolder_Click(object sender, EventArgs e)
        {
            Process.Start(LogFileManager.GetLogFolder());
        }

    }
}
