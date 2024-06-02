namespace SevenZipFrontend {
    partial class MainForm {
        private System.Windows.Forms.Button btnCreateArchive;
        private System.Windows.Forms.Button btnExtractArchive;
        private System.Windows.Forms.ComboBox compressionLevelComboBox;
        private System.Windows.Forms.Label compressionLevelLabel;
        private System.Windows.Forms.CheckBox chkPasswordProtected;

        private class PasswordForm : Form {
            public string Password { get; private set; }

            private TextBox passwordTextBox;
            private Button okButton;

            public PasswordForm() {
                InitializeComponent();
            }

            private void InitializeComponent() {
                this.passwordTextBox = new TextBox();
                this.Controls.Add(this.passwordTextBox);
                this.passwordTextBox.PasswordChar = '*'; // Hide the password input
                this.passwordTextBox.TextChanged += (sender, e) => {
                    this.Password = ((TextBox)sender).Text;
                };
                this.okButton = new Button();
                this.Controls.Add(this.okButton);
                this.okButton.Text = "OK";
                this.okButton.Dock = DockStyle.Bottom;
                this.okButton.Click += (sender, e) => {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                this.AcceptButton = this.okButton;
                this.StartPosition = FormStartPosition.CenterParent;
                this.ClientSize = new Size(200, 100);
            }
        }
        
        private void InitializeComponent() {
            // chkPasswordProtected
            this.chkPasswordProtected = new System.Windows.Forms.CheckBox();
            this.chkPasswordProtected.Location = new System.Drawing.Point(280, 20);
            this.chkPasswordProtected.Name = "chkPasswordProtected";
            this.chkPasswordProtected.Size = new System.Drawing.Size(120, 15);
            this.chkPasswordProtected.Text = "Password Protected";
            this.chkPasswordProtected.UseVisualStyleBackColor = true;
            this.Controls.Add(this.chkPasswordProtected);
            
            // the compression level options to the ComboBox
            this.compressionLevelComboBox = new System.Windows.Forms.ComboBox();
            this.Controls.Add(this.compressionLevelComboBox);
            this.compressionLevelComboBox.Items.AddRange(new object[] {
                "None",
                "Fast",
                "Normal",
                "Ultra"
            });
            this.compressionLevelComboBox.SelectedItem = "Normal";
            this.compressionLevelComboBox.Location = new System.Drawing.Point(150, 20);
            this.compressionLevelComboBox.Name = "compressionLevelComboBox";
            this.compressionLevelComboBox.Size = new System.Drawing.Size(100, 15);
            this.compressionLevelComboBox.TabIndex = 0;
            
            // compressionLevelLabel
            this.compressionLevelLabel = new System.Windows.Forms.Label();
            this.compressionLevelLabel.Location = new System.Drawing.Point(150, 5);
            this.compressionLevelLabel.Name = "compressionLevelLabel";
            this.compressionLevelLabel.Size = new System.Drawing.Size(100, 30);
            this.compressionLevelLabel.Text = "Compression Level:";
            this.Controls.Add(this.compressionLevelLabel);


            this.btnCreateArchive = new System.Windows.Forms.Button();
            this.btnExtractArchive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateArchive
            // 
            this.btnCreateArchive.Location = new System.Drawing.Point(15, 15);
            this.btnCreateArchive.Name = "btnCreateArchive";
            this.btnCreateArchive.Size = new System.Drawing.Size(120, 30);
            this.btnCreateArchive.TabIndex = 0;
            this.btnCreateArchive.Text = "Create Archive";
            this.btnCreateArchive.UseVisualStyleBackColor = true;
            this.btnCreateArchive.Click += new System.EventHandler(this.btnCreateArchive_Click);
            // 
            // btnExtractArchive
            // 
            this.btnExtractArchive.Location = new System.Drawing.Point(15, 45);
            this.btnExtractArchive.Name = "btnExtractArchive";
            this.btnExtractArchive.Size = new System.Drawing.Size(120, 30);
            this.btnExtractArchive.TabIndex = 1;
            this.btnExtractArchive.Text = "Extract Archive";
            this.btnExtractArchive.UseVisualStyleBackColor = true;
            this.btnExtractArchive.Click += new System.EventHandler(this.btnExtractArchive_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.btnExtractArchive);
            this.Controls.Add(this.btnCreateArchive);
            this.Name = "CSharks---LDS";
            this.Text = "CSharks---LDS - SevenZip Frontend";
            this.ResumeLayout(false);
        }
    }
}