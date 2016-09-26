namespace BluetoothServer
{
    partial class IconSlideForm
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
            this.indexName = new System.Windows.Forms.Label();
            this.deleteName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // indexName
            // 
            this.indexName.BackColor = System.Drawing.Color.White;
            this.indexName.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.indexName.ForeColor = System.Drawing.Color.Red;
            this.indexName.Location = new System.Drawing.Point(-1, 21);
            this.indexName.Name = "indexName";
            this.indexName.Size = new System.Drawing.Size(1203, 42);
            this.indexName.TabIndex = 0;
            this.indexName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteName
            // 
            this.deleteName.BackColor = System.Drawing.Color.White;
            this.deleteName.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deleteName.ForeColor = System.Drawing.Color.Blue;
            this.deleteName.Location = new System.Drawing.Point(-1, 63);
            this.deleteName.Name = "deleteName";
            this.deleteName.Size = new System.Drawing.Size(1203, 42);
            this.deleteName.TabIndex = 1;
            this.deleteName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IconSlideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1200, 361);
            this.ControlBox = false;
            this.Controls.Add(this.deleteName);
            this.Controls.Add(this.indexName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IconSlideForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.SystemColors.Window;
            this.Load += new System.EventHandler(this.IconSlideForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label indexName;
        private System.Windows.Forms.Label deleteName;
    }
}