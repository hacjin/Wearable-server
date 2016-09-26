namespace BluetoothServer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.boardbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.motionsetbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boardbtn
            // 
            this.boardbtn.AutoSize = true;
            this.boardbtn.BackColor = System.Drawing.Color.Transparent;
            this.boardbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("boardbtn.BackgroundImage")));
            this.boardbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.boardbtn.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.boardbtn.FlatAppearance.BorderSize = 0;
            this.boardbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.boardbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy;
            this.boardbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boardbtn.Location = new System.Drawing.Point(65, 162);
            this.boardbtn.Name = "boardbtn";
            this.boardbtn.Size = new System.Drawing.Size(200, 60);
            this.boardbtn.TabIndex = 0;
            this.boardbtn.UseVisualStyleBackColor = false;
            this.boardbtn.Click += new System.EventHandler(this.boardbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(294, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 764);
            this.panel1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // motionsetbtn
            // 
            this.motionsetbtn.BackColor = System.Drawing.Color.Transparent;
            this.motionsetbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("motionsetbtn.BackgroundImage")));
            this.motionsetbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.motionsetbtn.FlatAppearance.BorderSize = 0;
            this.motionsetbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.motionsetbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.motionsetbtn.Location = new System.Drawing.Point(65, 255);
            this.motionsetbtn.Name = "motionsetbtn";
            this.motionsetbtn.Size = new System.Drawing.Size(200, 60);
            this.motionsetbtn.TabIndex = 3;
            this.motionsetbtn.UseVisualStyleBackColor = false;
            this.motionsetbtn.Click += new System.EventHandler(this.motionsetbtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(984, 762);
            this.Controls.Add(this.motionsetbtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.boardbtn);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "요약남";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boardbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button motionsetbtn;
    }
}

