namespace Teknokraten
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UrlBox = new System.Windows.Forms.TextBox();
            this.DownloadBtnMp3 = new System.Windows.Forms.Button();
            this.DownloadBtnVideo = new System.Windows.Forms.Button();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UrlBox
            // 
            this.UrlBox.Location = new System.Drawing.Point(13, 13);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(259, 20);
            this.UrlBox.TabIndex = 0;
            // 
            // DownloadBtnMp3
            // 
            this.DownloadBtnMp3.Location = new System.Drawing.Point(13, 39);
            this.DownloadBtnMp3.Name = "DownloadBtnMp3";
            this.DownloadBtnMp3.Size = new System.Drawing.Size(115, 23);
            this.DownloadBtnMp3.TabIndex = 1;
            this.DownloadBtnMp3.Text = "Download MP3";
            this.DownloadBtnMp3.UseVisualStyleBackColor = true;
            // 
            // DownloadBtnVideo
            // 
            this.DownloadBtnVideo.Location = new System.Drawing.Point(151, 39);
            this.DownloadBtnVideo.Name = "DownloadBtnVideo";
            this.DownloadBtnVideo.Size = new System.Drawing.Size(121, 23);
            this.DownloadBtnVideo.TabIndex = 2;
            this.DownloadBtnVideo.Text = "Download Video";
            this.DownloadBtnVideo.UseVisualStyleBackColor = true;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(12, 84);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(35, 13);
            this.ResultLabel.TabIndex = 3;
            this.ResultLabel.Text = "label1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 133);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(260, 116);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.DownloadBtnVideo);
            this.Controls.Add(this.DownloadBtnMp3);
            this.Controls.Add(this.UrlBox);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
            DownloadBtnMp3.Click += DownloadBtnMp3_Click;
            DownloadBtnVideo.Click += DownloadBtnVideo_Click;
        }

        #endregion

        private System.Windows.Forms.TextBox UrlBox;
        private System.Windows.Forms.Button DownloadBtnMp3;
        private System.Windows.Forms.Button DownloadBtnVideo;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

