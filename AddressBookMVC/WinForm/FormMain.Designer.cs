namespace WinForm
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnContactList = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGroupList = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPwd = new System.Windows.Forms.ToolStripButton();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiContactMng = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContactList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContactAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroupMng = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroupList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroupAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSystemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsslblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnContactList,
            this.tsbtnGroupList,
            this.tsbtnPwd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(606, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnContactList
            // 
            this.tsbtnContactList.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnContactList.Image")));
            this.tsbtnContactList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnContactList.Name = "tsbtnContactList";
            this.tsbtnContactList.Size = new System.Drawing.Size(88, 22);
            this.tsbtnContactList.Text = "联系人列表";
            this.tsbtnContactList.Click += new System.EventHandler(this.tsmiContactList_Click);
            // 
            // tsbtnGroupList
            // 
            this.tsbtnGroupList.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGroupList.Image")));
            this.tsbtnGroupList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGroupList.Name = "tsbtnGroupList";
            this.tsbtnGroupList.Size = new System.Drawing.Size(76, 22);
            this.tsbtnGroupList.Text = "分组列表";
            this.tsbtnGroupList.Click += new System.EventHandler(this.tsmiGroupList_Click);
            // 
            // tsbtnPwd
            // 
            this.tsbtnPwd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPwd.Image")));
            this.tsbtnPwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPwd.Name = "tsbtnPwd";
            this.tsbtnPwd.Size = new System.Drawing.Size(76, 22);
            this.tsbtnPwd.Text = "修改密码";
            this.tsbtnPwd.Click += new System.EventHandler(this.tsmiPwd_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(152, 22);
            this.tsmiAbout.Text = "关于";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiContactMng,
            this.tsmiGroupMng,
            this.tsmiSystemManage,
            this.tsmiHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(606, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiContactMng
            // 
            this.tsmiContactMng.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiContactList,
            this.tsmiContactAdd});
            this.tsmiContactMng.Name = "tsmiContactMng";
            this.tsmiContactMng.Size = new System.Drawing.Size(80, 21);
            this.tsmiContactMng.Text = "联系人管理";
            // 
            // tsmiContactList
            // 
            this.tsmiContactList.Name = "tsmiContactList";
            this.tsmiContactList.Size = new System.Drawing.Size(152, 22);
            this.tsmiContactList.Text = "联系人列表";
            this.tsmiContactList.Click += new System.EventHandler(this.tsmiContactList_Click);
            // 
            // tsmiContactAdd
            // 
            this.tsmiContactAdd.Name = "tsmiContactAdd";
            this.tsmiContactAdd.Size = new System.Drawing.Size(152, 22);
            this.tsmiContactAdd.Text = "增加联系人";
            this.tsmiContactAdd.Click += new System.EventHandler(this.tsmiContactAdd_Click);
            // 
            // tsmiGroupMng
            // 
            this.tsmiGroupMng.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGroupList,
            this.tsmiGroupAdd});
            this.tsmiGroupMng.Name = "tsmiGroupMng";
            this.tsmiGroupMng.Size = new System.Drawing.Size(68, 21);
            this.tsmiGroupMng.Text = "分组管理";
            // 
            // tsmiGroupList
            // 
            this.tsmiGroupList.Name = "tsmiGroupList";
            this.tsmiGroupList.Size = new System.Drawing.Size(152, 22);
            this.tsmiGroupList.Text = "分组列表";
            this.tsmiGroupList.Click += new System.EventHandler(this.tsmiGroupList_Click);
            // 
            // tsmiGroupAdd
            // 
            this.tsmiGroupAdd.Name = "tsmiGroupAdd";
            this.tsmiGroupAdd.Size = new System.Drawing.Size(152, 22);
            this.tsmiGroupAdd.Text = "增加分组";
            this.tsmiGroupAdd.Click += new System.EventHandler(this.tsmiGroupAdd_Click);
            // 
            // tsmiSystemManage
            // 
            this.tsmiSystemManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPwd,
            this.tsmiDatabase});
            this.tsmiSystemManage.Name = "tsmiSystemManage";
            this.tsmiSystemManage.Size = new System.Drawing.Size(68, 21);
            this.tsmiSystemManage.Text = "系统管理";
            // 
            // tsmiPwd
            // 
            this.tsmiPwd.Name = "tsmiPwd";
            this.tsmiPwd.Size = new System.Drawing.Size(172, 22);
            this.tsmiPwd.Text = "修改密码";
            this.tsmiPwd.Click += new System.EventHandler(this.tsmiPwd_Click);
            // 
            // tsmiDatabase
            // 
            this.tsmiDatabase.Name = "tsmiDatabase";
            this.tsmiDatabase.Size = new System.Drawing.Size(172, 22);
            this.tsmiDatabase.Text = "数据库备份与恢复";
            this.tsmiDatabase.Click += new System.EventHandler(this.tsmiDatabase_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 21);
            this.tsmiHelp.Text = "帮助";
            // 
            // tsslblDate
            // 
            this.tsslblDate.Name = "tsslblDate";
            this.tsslblDate.Size = new System.Drawing.Size(131, 17);
            this.tsslblDate.Text = "toolStripStatusLabel2";
            // 
            // tsslblUserName
            // 
            this.tsslblUserName.Name = "tsslblUserName";
            this.tsslblUserName.Size = new System.Drawing.Size(131, 17);
            this.tsslblUserName.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblUserName,
            this.tsslblDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(606, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(137, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "联系你我他，沟通无极限";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 423);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "我的通讯录";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnContactList;
        private System.Windows.Forms.ToolStripButton tsbtnGroupList;
        private System.Windows.Forms.ToolStripButton tsbtnPwd;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiContactMng;
        private System.Windows.Forms.ToolStripMenuItem tsmiContactList;
        private System.Windows.Forms.ToolStripMenuItem tsmiContactAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroupMng;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroupList;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroupAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystemManage;
        private System.Windows.Forms.ToolStripMenuItem tsmiPwd;
        private System.Windows.Forms.ToolStripMenuItem tsmiDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripStatusLabel tsslblDate;
        private System.Windows.Forms.ToolStripStatusLabel tsslblUserName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
    }
}