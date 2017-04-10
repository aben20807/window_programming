namespace UrlTest
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
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxVideo = new System.Windows.Forms.CheckedListBox();
            this.buttonOpenall = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonFind
            // 
            this.buttonFind.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFind.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonFind.Location = new System.Drawing.Point(161, 115);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(129, 129);
            this.buttonFind.TabIndex = 0;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxUrl.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxUrl.Location = new System.Drawing.Point(76, 12);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(650, 30);
            this.textBoxUrl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL :";
            // 
            // checkedListBoxVideo
            // 
            this.checkedListBoxVideo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkedListBoxVideo.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkedListBoxVideo.FormattingEnabled = true;
            this.checkedListBoxVideo.Items.AddRange(new object[] {
            "mp4",
            "flv",
            "wav",
            "avi"});
            this.checkedListBoxVideo.Location = new System.Drawing.Point(76, 115);
            this.checkedListBoxVideo.Name = "checkedListBoxVideo";
            this.checkedListBoxVideo.Size = new System.Drawing.Size(79, 129);
            this.checkedListBoxVideo.TabIndex = 3;
            // 
            // buttonOpenall
            // 
            this.buttonOpenall.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonOpenall.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonOpenall.Location = new System.Drawing.Point(597, 115);
            this.buttonOpenall.Name = "buttonOpenall";
            this.buttonOpenall.Size = new System.Drawing.Size(129, 129);
            this.buttonOpenall.TabIndex = 5;
            this.buttonOpenall.Text = "Open all";
            this.buttonOpenall.UseVisualStyleBackColor = true;
            this.buttonOpenall.Click += new System.EventHandler(this.buttonOpenall_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelStatus.Location = new System.Drawing.Point(212, 273);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(59, 22);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Status";
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBoxAll.Location = new System.Drawing.Point(76, 82);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(52, 26);
            this.checkBoxAll.TabIndex = 7;
            this.checkBoxAll.Text = "All";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxStatus.Location = new System.Drawing.Point(296, 115);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(295, 129);
            this.textBoxStatus.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 321);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonOpenall);
            this.Controls.Add(this.checkedListBoxVideo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.buttonFind);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxVideo;
        private System.Windows.Forms.Button buttonOpenall;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.TextBox textBoxStatus;
    }
}

