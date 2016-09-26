namespace BluetoothServer
{
    partial class SettingMotionForm
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingMotionForm));
            this.rightbtn = new System.Windows.Forms.Button();
            this.centerbtn = new System.Windows.Forms.Button();
            this.leftbtn = new System.Windows.Forms.Button();
            this.upbtn = new System.Windows.Forms.Button();
            this.downbtn = new System.Windows.Forms.Button();
            this.fucbox = new System.Windows.Forms.ListBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pptbtn = new System.Windows.Forms.Button();
            this.gombtn = new System.Windows.Forms.Button();
            this.mariobtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.iconList = new System.Windows.Forms.ListView();
            this.iconView = new System.Windows.Forms.ImageList(this.components);
            this.leftRbtn = new System.Windows.Forms.Button();
            this.rightRbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rightbtn
            // 
            this.rightbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightbtn.BackgroundImage")));
            this.rightbtn.Location = new System.Drawing.Point(147, 235);
            this.rightbtn.Name = "rightbtn";
            this.rightbtn.Size = new System.Drawing.Size(36, 36);
            this.rightbtn.TabIndex = 0;
            this.rightbtn.UseVisualStyleBackColor = true;
            this.rightbtn.Click += new System.EventHandler(this.rightbtn_Click);
            // 
            // centerbtn
            // 
            this.centerbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("centerbtn.BackgroundImage")));
            this.centerbtn.Location = new System.Drawing.Point(105, 235);
            this.centerbtn.Name = "centerbtn";
            this.centerbtn.Size = new System.Drawing.Size(36, 36);
            this.centerbtn.TabIndex = 0;
            this.centerbtn.UseVisualStyleBackColor = true;
            // 
            // leftbtn
            // 
            this.leftbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftbtn.BackgroundImage")));
            this.leftbtn.Location = new System.Drawing.Point(63, 235);
            this.leftbtn.Name = "leftbtn";
            this.leftbtn.Size = new System.Drawing.Size(36, 36);
            this.leftbtn.TabIndex = 0;
            this.leftbtn.UseVisualStyleBackColor = true;
            this.leftbtn.Click += new System.EventHandler(this.leftbtn_Click);
            // 
            // upbtn
            // 
            this.upbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("upbtn.BackgroundImage")));
            this.upbtn.Location = new System.Drawing.Point(105, 193);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(36, 36);
            this.upbtn.TabIndex = 0;
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click);
            // 
            // downbtn
            // 
            this.downbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("downbtn.BackgroundImage")));
            this.downbtn.Location = new System.Drawing.Point(105, 277);
            this.downbtn.Name = "downbtn";
            this.downbtn.Size = new System.Drawing.Size(36, 36);
            this.downbtn.TabIndex = 0;
            this.downbtn.UseVisualStyleBackColor = true;
            this.downbtn.Click += new System.EventHandler(this.downbtn_Click);
            // 
            // fucbox
            // 
            this.fucbox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.fucbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.fucbox.FormattingEnabled = true;
            this.fucbox.ItemHeight = 12;
            this.fucbox.Location = new System.Drawing.Point(483, 193);
            this.fucbox.Name = "fucbox";
            this.fucbox.Size = new System.Drawing.Size(171, 124);
            this.fucbox.TabIndex = 1;
            // 
            // savebtn
            // 
            this.savebtn.Image = ((System.Drawing.Image)(resources.GetObject("savebtn.Image")));
            this.savebtn.Location = new System.Drawing.Point(324, 305);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(80, 40);
            this.savebtn.TabIndex = 2;
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(63, 437);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(591, 134);
            this.textBox1.TabIndex = 3;
            // 
            // pptbtn
            // 
            this.pptbtn.BackgroundImage = global::BluetoothServer.Properties.Resources.pptbtn1;
            this.pptbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pptbtn.Location = new System.Drawing.Point(119, 363);
            this.pptbtn.Name = "pptbtn";
            this.pptbtn.Size = new System.Drawing.Size(159, 36);
            this.pptbtn.TabIndex = 4;
            this.pptbtn.UseVisualStyleBackColor = true;
            this.pptbtn.Click += new System.EventHandler(this.pptbtn_Click);
            // 
            // gombtn
            // 
            this.gombtn.BackgroundImage = global::BluetoothServer.Properties.Resources.gombtn;
            this.gombtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gombtn.Location = new System.Drawing.Point(284, 363);
            this.gombtn.Name = "gombtn";
            this.gombtn.Size = new System.Drawing.Size(159, 36);
            this.gombtn.TabIndex = 5;
            this.gombtn.UseVisualStyleBackColor = true;
            this.gombtn.Click += new System.EventHandler(this.gombtn_Click);
            // 
            // mariobtn
            // 
            this.mariobtn.BackgroundImage = global::BluetoothServer.Properties.Resources.mariobtn;
            this.mariobtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mariobtn.Location = new System.Drawing.Point(449, 363);
            this.mariobtn.Name = "mariobtn";
            this.mariobtn.Size = new System.Drawing.Size(159, 36);
            this.mariobtn.TabIndex = 6;
            this.mariobtn.UseVisualStyleBackColor = true;
            this.mariobtn.Click += new System.EventHandler(this.mariobtn_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::BluetoothServer.Properties.Resources.markbtn;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(495, 620);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 36);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iconList
            // 
            this.iconList.LargeImageList = this.iconView;
            this.iconList.Location = new System.Drawing.Point(3, 662);
            this.iconList.Name = "iconList";
            this.iconList.Size = new System.Drawing.Size(691, 85);
            this.iconList.SmallImageList = this.iconView;
            this.iconList.TabIndex = 8;
            this.iconList.UseCompatibleStateImageBehavior = false;
            this.iconList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.iconList_MouseDoubleClick);
            // 
            // iconView
            // 
            this.iconView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iconView.ImageSize = new System.Drawing.Size(60, 60);
            this.iconView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // leftRbtn
            // 
            this.leftRbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftRbtn.BackgroundImage")));
            this.leftRbtn.Location = new System.Drawing.Point(63, 193);
            this.leftRbtn.Name = "leftRbtn";
            this.leftRbtn.Size = new System.Drawing.Size(36, 36);
            this.leftRbtn.TabIndex = 9;
            this.leftRbtn.UseVisualStyleBackColor = true;
            this.leftRbtn.Click += new System.EventHandler(this.leftRbtn_Click);
            // 
            // rightRbtn
            // 
            this.rightRbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightRbtn.BackgroundImage")));
            this.rightRbtn.Location = new System.Drawing.Point(147, 277);
            this.rightRbtn.Name = "rightRbtn";
            this.rightRbtn.Size = new System.Drawing.Size(36, 36);
            this.rightRbtn.TabIndex = 10;
            this.rightRbtn.UseVisualStyleBackColor = true;
            this.rightRbtn.Click += new System.EventHandler(this.rightRbtn_Click);
            // 
            // SettingMotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.rightRbtn);
            this.Controls.Add(this.leftRbtn);
            this.Controls.Add(this.iconList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mariobtn);
            this.Controls.Add(this.gombtn);
            this.Controls.Add(this.pptbtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.fucbox);
            this.Controls.Add(this.downbtn);
            this.Controls.Add(this.upbtn);
            this.Controls.Add(this.leftbtn);
            this.Controls.Add(this.centerbtn);
            this.Controls.Add(this.rightbtn);
            this.Name = "SettingMotionForm";
            this.Size = new System.Drawing.Size(691, 764);
            this.Load += new System.EventHandler(this.SettingMotionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rightbtn;
        private System.Windows.Forms.Button centerbtn;
        private System.Windows.Forms.Button leftbtn;
        private System.Windows.Forms.Button upbtn;
        private System.Windows.Forms.Button downbtn;
        private System.Windows.Forms.ListBox fucbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button pptbtn;
        private System.Windows.Forms.Button gombtn;
        private System.Windows.Forms.Button mariobtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView iconList;
        private System.Windows.Forms.ImageList iconView;
        private System.Windows.Forms.Button leftRbtn;
        private System.Windows.Forms.Button rightRbtn;
    }
}
