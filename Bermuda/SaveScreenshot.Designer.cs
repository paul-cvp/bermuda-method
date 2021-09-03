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
            this.groupBoxImageHighlighting = new System.Windows.Forms.GroupBox();
            this.comboBoxToolTipItem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelColorPicker = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBrushSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarThickness = new System.Windows.Forms.TrackBar();
            this.buttonClear = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).BeginInit();
            this.groupBoxImageHighlighting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCapture
            // 
            this.pbCapture.Location = new System.Drawing.Point(9, 33);
            this.pbCapture.Name = "pbCapture";
            this.pbCapture.Size = new System.Drawing.Size(429, 208);
            this.pbCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCapture.TabIndex = 0;
            this.pbCapture.TabStop = false;
            this.pbCapture.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCapture_Paint);
            this.pbCapture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbCapture_MouseDown);
            this.pbCapture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbCapture_MouseMove);
            this.pbCapture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbCapture_MouseUp);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(88, 4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Cancel";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRecapture
            // 
            this.btnRecapture.Location = new System.Drawing.Point(168, 4);
            this.btnRecapture.Name = "btnRecapture";
            this.btnRecapture.Size = new System.Drawing.Size(75, 23);
            this.btnRecapture.TabIndex = 3;
            this.btnRecapture.Text = "Recapture";
            this.btnRecapture.UseVisualStyleBackColor = true;
            this.btnRecapture.Click += new System.EventHandler(this.buttonRecapture_Click);
            // 
            // groupBoxImageHighlighting
            // 
            this.groupBoxImageHighlighting.Controls.Add(this.comboBoxToolTipItem);
            this.groupBoxImageHighlighting.Controls.Add(this.label3);
            this.groupBoxImageHighlighting.Controls.Add(this.labelColorPicker);
            this.groupBoxImageHighlighting.Controls.Add(this.label2);
            this.groupBoxImageHighlighting.Controls.Add(this.labelBrushSize);
            this.groupBoxImageHighlighting.Controls.Add(this.label1);
            this.groupBoxImageHighlighting.Controls.Add(this.trackBarThickness);
            this.groupBoxImageHighlighting.Controls.Add(this.buttonClear);
            this.groupBoxImageHighlighting.Location = new System.Drawing.Point(444, 14);
            this.groupBoxImageHighlighting.Name = "groupBoxImageHighlighting";
            this.groupBoxImageHighlighting.Size = new System.Drawing.Size(200, 227);
            this.groupBoxImageHighlighting.TabIndex = 4;
            this.groupBoxImageHighlighting.TabStop = false;
            this.groupBoxImageHighlighting.Text = "Image Highlighting options";
            // 
            // comboBoxToolTipItem
            // 
            this.comboBoxToolTipItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxToolTipItem.FormattingEnabled = true;
            this.comboBoxToolTipItem.Items.AddRange(new object[] {
            "Pen",
            "Line",
            "Rectangle",
            "Elipse"});
            this.comboBoxToolTipItem.Location = new System.Drawing.Point(6, 130);
            this.comboBoxToolTipItem.Name = "comboBoxToolTipItem";
            this.comboBoxToolTipItem.Size = new System.Drawing.Size(150, 21);
            this.comboBoxToolTipItem.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tool tip item";
            // 
            // labelColorPicker
            // 
            this.labelColorPicker.AutoSize = true;
            this.labelColorPicker.BackColor = System.Drawing.Color.Black;
            this.labelColorPicker.Location = new System.Drawing.Point(6, 92);
            this.labelColorPicker.Name = "labelColorPicker";
            this.labelColorPicker.Size = new System.Drawing.Size(67, 13);
            this.labelColorPicker.TabIndex = 9;
            this.labelColorPicker.Text = "                    ";
            this.labelColorPicker.Click += new System.EventHandler(this.labelColorPicker_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Color";
            // 
            // labelBrushSize
            // 
            this.labelBrushSize.AutoSize = true;
            this.labelBrushSize.Location = new System.Drawing.Point(58, 28);
            this.labelBrushSize.Name = "labelBrushSize";
            this.labelBrushSize.Size = new System.Drawing.Size(0, 13);
            this.labelBrushSize.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Brush size";
            // 
            // trackBarThickness
            // 
            this.trackBarThickness.Location = new System.Drawing.Point(6, 44);
            this.trackBarThickness.Name = "trackBarThickness";
            this.trackBarThickness.Size = new System.Drawing.Size(188, 45);
            this.trackBarThickness.TabIndex = 5;
            this.trackBarThickness.Scroll += new System.EventHandler(this.trackBarThickness_Scroll);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(6, 198);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Text = "Clear All";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // SaveScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(651, 247);
            this.Controls.Add(this.groupBoxImageHighlighting);
            this.Controls.Add(this.btnRecapture);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbCapture);
            this.Name = "SaveScreenshot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Save_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).EndInit();
            this.groupBoxImageHighlighting.ResumeLayout(false);
            this.groupBoxImageHighlighting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCapture;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRecapture;
        private System.Windows.Forms.GroupBox groupBoxImageHighlighting;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TrackBar trackBarThickness;
        private System.Windows.Forms.Label labelBrushSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelColorPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBoxToolTipItem;
        private System.Windows.Forms.Label label3;
    }
}