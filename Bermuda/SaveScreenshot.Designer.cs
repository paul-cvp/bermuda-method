namespace Bermuda
{
    partial class SaveScreenshot
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
            this.pbCapture = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRecapture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCapture
            // 
            this.pbCapture.Location = new System.Drawing.Point(14, 51);
            this.pbCapture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbCapture.Name = "pbCapture";
            this.pbCapture.Size = new System.Drawing.Size(429, 208);
            this.pbCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCapture.TabIndex = 0;
            this.pbCapture.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(255, 6);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(112, 35);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Cancel";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRecapture
            // 
            this.btnRecapture.Location = new System.Drawing.Point(134, 6);
            this.btnRecapture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecapture.Name = "btnRecapture";
            this.btnRecapture.Size = new System.Drawing.Size(112, 35);
            this.btnRecapture.TabIndex = 3;
            this.btnRecapture.Text = "Recapture";
            this.btnRecapture.UseVisualStyleBackColor = true;
            this.btnRecapture.Click += new System.EventHandler(this.buttonRecapture_Click);
            // 
            // SaveScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(668, 380);
            this.Controls.Add(this.btnRecapture);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbCapture);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SaveScreenshot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Save_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCapture;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRecapture;
    }
}