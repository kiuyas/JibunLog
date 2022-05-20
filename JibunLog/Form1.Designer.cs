namespace JibunLog
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtViewer = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.timScroll = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.再読込ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.過去ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.区切るToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtViewer
            // 
            this.txtViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtViewer.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtViewer.Location = new System.Drawing.Point(0, 0);
            this.txtViewer.Multiline = true;
            this.txtViewer.Name = "txtViewer";
            this.txtViewer.ReadOnly = true;
            this.txtViewer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtViewer.Size = new System.Drawing.Size(608, 301);
            this.txtViewer.TabIndex = 0;
            this.txtViewer.TabStop = false;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInput.Size = new System.Drawing.Size(560, 102);
            this.txtInput.TabIndex = 1;
            // 
            // btnWrite
            // 
            this.btnWrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWrite.Location = new System.Drawing.Point(560, 0);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(48, 103);
            this.btnWrite.TabIndex = 2;
            this.btnWrite.Text = "書込";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtViewer);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtInput);
            this.splitContainer1.Panel2.Controls.Add(this.btnWrite);
            this.splitContainer1.Panel2MinSize = 64;
            this.splitContainer1.Size = new System.Drawing.Size(608, 408);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.TabIndex = 3;
            // 
            // timScroll
            // 
            this.timScroll.Tick += new System.EventHandler(this.timScroll_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.編集EToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.再読込ToolStripMenuItem,
            this.過去ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 再読込ToolStripMenuItem
            // 
            this.再読込ToolStripMenuItem.Name = "再読込ToolStripMenuItem";
            this.再読込ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.再読込ToolStripMenuItem.Text = "再読込";
            this.再読込ToolStripMenuItem.Click += new System.EventHandler(this.再読込ToolStripMenuItem_Click);
            // 
            // 過去ToolStripMenuItem
            // 
            this.過去ToolStripMenuItem.Name = "過去ToolStripMenuItem";
            this.過去ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.過去ToolStripMenuItem.Text = "過去";
            this.過去ToolStripMenuItem.Click += new System.EventHandler(this.過去ToolStripMenuItem_Click);
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.編集ToolStripMenuItem1,
            this.区切るToolStripMenuItem});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.編集EToolStripMenuItem.Text = "編集(&E)";
            // 
            // 編集ToolStripMenuItem1
            // 
            this.編集ToolStripMenuItem1.Name = "編集ToolStripMenuItem1";
            this.編集ToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.編集ToolStripMenuItem1.Text = "編集";
            this.編集ToolStripMenuItem1.Click += new System.EventHandler(this.編集ToolStripMenuItem1_Click);
            // 
            // 区切るToolStripMenuItem
            // 
            this.区切るToolStripMenuItem.Name = "区切るToolStripMenuItem";
            this.区切るToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.区切るToolStripMenuItem.Text = "区切る";
            this.区切るToolStripMenuItem.Click += new System.EventHandler(this.区切るToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "自分ログ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtViewer;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timScroll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 再読込ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 過去ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 区切るToolStripMenuItem;
    }
}

