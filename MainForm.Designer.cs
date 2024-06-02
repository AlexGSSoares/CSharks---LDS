namespace SevenZipFrontend {
    partial class MainForm {
        private System.Windows.Forms.Button btnCreateArchive;
        private System.Windows.Forms.Button btnExtractArchive;

        private void InitializeComponent() {
            this.btnCreateArchive = new System.Windows.Forms.Button();
            this.btnExtractArchive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateArchive
            // 
            this.btnCreateArchive.Location = new System.Drawing.Point(12, 12);
            this.btnCreateArchive.Name = "btnCreateArchive";
            this.btnCreateArchive.Size = new System.Drawing.Size(100, 23);
            this.btnCreateArchive.TabIndex = 0;
            this.btnCreateArchive.Text = "Create Archive";
            this.btnCreateArchive.UseVisualStyleBackColor = true;
            this.btnCreateArchive.Click += new System.EventHandler(this.btnCreateArchive_Click);
            // 
            // btnExtractArchive
            // 
            this.btnExtractArchive.Location = new System.Drawing.Point(12, 41);
            this.btnExtractArchive.Name = "btnExtractArchive";
            this.btnExtractArchive.Size = new System.Drawing.Size(100, 23);
            this.btnExtractArchive.TabIndex = 1;
            this.btnExtractArchive.Text = "Extract Archive";
            this.btnExtractArchive.UseVisualStyleBackColor = true;
            this.btnExtractArchive.Click += new System.EventHandler(this.btnExtractArchive_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(this.btnExtractArchive);
            this.Controls.Add(this.btnCreateArchive);
            this.Name = "CSharks---LDS";
            this.Text = "CSharks---LDS - SevenZip Frontend";
            this.ResumeLayout(false);
        }
    }
}