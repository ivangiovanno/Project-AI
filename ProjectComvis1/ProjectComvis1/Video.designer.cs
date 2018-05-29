namespace ProjectComvis
{
    partial class Video
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbNose = new System.Windows.Forms.CheckBox();
            this.cbEyes = new System.Windows.Forms.CheckBox();
            this.cbFace = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(391, 211);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbNose);
            this.groupBox1.Controls.Add(this.cbEyes);
            this.groupBox1.Controls.Add(this.cbFace);
            this.groupBox1.Location = new System.Drawing.Point(12, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detection Type";
            // 
            // cbNose
            // 
            this.cbNose.AutoSize = true;
            this.cbNose.Location = new System.Drawing.Point(170, 19);
            this.cbNose.Name = "cbNose";
            this.cbNose.Size = new System.Drawing.Size(51, 17);
            this.cbNose.TabIndex = 0;
            this.cbNose.Text = "Nose";
            this.cbNose.UseVisualStyleBackColor = true;
            // 
            // cbEyes
            // 
            this.cbEyes.AutoSize = true;
            this.cbEyes.Location = new System.Drawing.Point(315, 19);
            this.cbEyes.Name = "cbEyes";
            this.cbEyes.Size = new System.Drawing.Size(49, 17);
            this.cbEyes.TabIndex = 0;
            this.cbEyes.Text = "Eyes";
            this.cbEyes.UseVisualStyleBackColor = true;
            // 
            // cbFace
            // 
            this.cbFace.AutoSize = true;
            this.cbFace.Location = new System.Drawing.Point(7, 20);
            this.cbFace.Name = "cbFace";
            this.cbFace.Size = new System.Drawing.Size(50, 17);
            this.cbFace.TabIndex = 0;
            this.cbFace.Text = "Face";
            this.cbFace.UseVisualStyleBackColor = true;
            // 
            // Video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 286);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Video";
            this.Text = "insafGram";
            this.Load += new System.EventHandler(this.Video_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbNose;
        private System.Windows.Forms.CheckBox cbEyes;
        private System.Windows.Forms.CheckBox cbFace;
    }
}