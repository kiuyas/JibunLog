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
                    // 書き込む内容を取得する
                    string log = LogFileManager.GetLogSentence(txtInput.Text);

                    // 入力内容を渡してWriteメソッドを呼び出す
                    LogFileManager.Write(log);

                    // テキストビューア更新
                    txtViewer.AppendText(log);

                    // 入力欄をクリアする。
                    txtInput.Clear();

                    // スクロール位置調整
                    MoveToLast();
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
                timScroll.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// 再読込ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            ShowLog();
        }

        /// <summary>
        /// 過去ログフォルダを表示します。
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void btnLogFolder_Click(object sender, EventArgs e)
        {
            Process.Start(LogFileManager.GetLogFolder());
            txtInput.Focus();
        }

        /// <summary>
        /// スクロールタイマーTICK時処理
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void timScroll_Tick(object sender, EventArgs e)
        {
            timScroll.Stop();
            MoveToLast();
        }

        /// <summary>
        /// ビュアーのスクロール位置を最終行に合わせます。
        /// </summary>
        private void MoveToLast()
        {
            txtViewer.SelectionStart = txtViewer.Text.Length;
            txtViewer.Focus();
            txtViewer.ScrollToCaret();
            txtInput.Focus();
        }
    }
}
