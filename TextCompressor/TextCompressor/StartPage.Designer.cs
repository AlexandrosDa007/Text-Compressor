namespace TextCompressor
{
    partial class StartPage
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
            this.compressButton = new System.Windows.Forms.Button();
            this.decompressButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // compressButton
            // 
            this.compressButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.compressButton.Location = new System.Drawing.Point(112, 23);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(181, 56);
            this.compressButton.TabIndex = 0;
            this.compressButton.Text = "Compress Files";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.compressButton_Click);
            // 
            // decompressButton
            // 
            this.decompressButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.decompressButton.Location = new System.Drawing.Point(112, 102);
            this.decompressButton.Name = "decompressButton";
            this.decompressButton.Size = new System.Drawing.Size(181, 56);
            this.decompressButton.TabIndex = 1;
            this.decompressButton.Text = "Decompress Files";
            this.decompressButton.UseVisualStyleBackColor = true;
            this.decompressButton.Click += new System.EventHandler(this.decompressButton_Click);
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 201);
            this.Controls.Add(this.decompressButton);
            this.Controls.Add(this.compressButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Compressor - by alexdaltsis";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button compressButton;
        private System.Windows.Forms.Button decompressButton;
    }
}