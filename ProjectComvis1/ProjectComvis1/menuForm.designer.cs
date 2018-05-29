namespace ProjectComvis
{
    partial class menuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.browseImage = new System.Windows.Forms.Button();
            this.captureImage = new System.Windows.Forms.Button();
            this.browseVideo = new System.Windows.Forms.Button();
            this.signOut = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "MENU";
            // 
            // browseImage
            // 
            this.browseImage.Location = new System.Drawing.Point(22, 64);
            this.browseImage.Name = "browseImage";
            this.browseImage.Size = new System.Drawing.Size(237, 30);
            this.browseImage.TabIndex = 3;
            this.browseImage.Text = "Browse Image";
            this.browseImage.UseVisualStyleBackColor = true;
            this.browseImage.Click += new System.EventHandler(this.browseImage_Click);
            // 
            // captureImage
            // 
            this.captureImage.Location = new System.Drawing.Point(22, 108);
            this.captureImage.Name = "captureImage";
            this.captureImage.Size = new System.Drawing.Size(237, 30);
            this.captureImage.TabIndex = 4;
            this.captureImage.Text = "Capture Image";
            this.captureImage.UseVisualStyleBackColor = true;
            this.captureImage.Click += new System.EventHandler(this.captureImage_Click);
            // 
            // browseVideo
            // 
            this.browseVideo.Location = new System.Drawing.Point(22, 153);
            this.browseVideo.Name = "browseVideo";
            this.browseVideo.Size = new System.Drawing.Size(237, 30);
            this.browseVideo.TabIndex = 5;
            this.browseVideo.Text = "Browse Video";
            this.browseVideo.UseVisualStyleBackColor = true;
            this.browseVideo.Click += new System.EventHandler(this.browseVideo_Click);
            // 
            // signOut
            // 
            this.signOut.Location = new System.Drawing.Point(22, 196);
            this.signOut.Name = "signOut";
            this.signOut.Size = new System.Drawing.Size(237, 30);
            this.signOut.TabIndex = 6;
            this.signOut.Text = "Sign Out";
            this.signOut.UseVisualStyleBackColor = true;
            this.signOut.Click += new System.EventHandler(this.signOut_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.signOut);
            this.Controls.Add(this.browseVideo);
            this.Controls.Add(this.captureImage);
            this.Controls.Add(this.browseImage);
            this.Controls.Add(this.label1);
            this.Name = "menuForm";
            this.Text = "insafGram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseImage;
        private System.Windows.Forms.Button captureImage;
        private System.Windows.Forms.Button browseVideo;
        private System.Windows.Forms.Button signOut;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}