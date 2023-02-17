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
        #region 初期処理

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            PrepareFolder();

            ShowLog();
        }

        /// <summary>
        /// 出力フォルダの準備
        /// </summary>
        private void PrepareFolder()
        {
            string logFolderPath = LogFileManager.GetLogFolder();

            if (logFolderPath == null)
            {
                MessageBox.Show(this, "ログフォルダを作成できません。終了します。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }
        }

        #endregion

        #region イベント

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
            if (txtInput.Text != "")
            {
                // 書き込む内容を取得する
                string log = LogFileManager.GetLogSentence(txtInput.Text);
                // 書き込む
                Write(log);
                // 入力欄をクリアする。
                txtInput.Clear();
            }
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

        #endregion

        #region ファンクション

        private void 再読込ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void 過去ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOldLogFolder();
        }

        private void 編集ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditThisMonth();
        }

        private void 区切るToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSeparator();
        }

        #endregion

        #region コンテキストメニュー

        /// <summary>
        /// 引用符付き貼り付け
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 引用符付き貼り付けQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                txtInput.AppendText(LogFileManager.MakeQuotedString(text));
            }
        }

        #endregion

        #region 処理

        /// <summary>
        /// 再読込ボタン押下時処理
        /// </summary>
        private void Reload()
        {
            ShowLog();
        }

        /// <summary>
        /// 過去ログフォルダを表示します。
        /// </summary>
        private void ShowOldLogFolder()
        {
            Process.Start(LogFileManager.GetLogFolder());
            txtInput.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        private void EditThisMonth()
        {
            Process.Start(LogFileManager.GetLogFilePath());
        }

        /// <summary>
        /// 区切り線を書き込みます。
        /// </summary>
        private void AddSeparator()
        {
            string log = "============================================================ "
                + LogFileManager.GetDateString() + LogFileManager.LINE_SEPARATOR + LogFileManager.LINE_SEPARATOR;
            Write(log);
        }

        /// <summary>
        /// ログを書き込む
        /// </summary>
        /// <param name="log"></param>
        private void Write(string log)
        {
            try
            {
                // 入力内容を渡してWriteメソッドを呼び出す
                LogFileManager.Write(log);

                // テキストビューア更新
                txtViewer.AppendText(log);

                // スクロール位置調整
                MoveToLast();
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
        /// ビュアーのスクロール位置を最終行に合わせます。
        /// </summary>
        private void MoveToLast()
        {
            txtViewer.SelectionStart = txtViewer.Text.Length;
            txtViewer.Focus();
            txtViewer.ScrollToCaret();
            txtInput.Focus();
        }

        #endregion

    }
}
