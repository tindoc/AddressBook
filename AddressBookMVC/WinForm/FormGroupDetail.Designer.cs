namespace WinForm
{
    partial class FormGroupDetail
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblGroupMemo = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGroupMemo = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(94, 17);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(173, 21);
            this.txtId.TabIndex = 8;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(18, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(53, 12);
            this.lblId.TabIndex = 13;
            this.lblId.Text = "分组编号";
            // 
            // lblGroupMemo
            // 
            this.lblGroupMemo.AutoSize = true;
            this.lblGroupMemo.Location = new System.Drawing.Point(18, 89);
            this.lblGroupMemo.Name = "lblGroupMemo";
            this.lblGroupMemo.Size = new System.Drawing.Size(29, 12);
            this.lblGroupMemo.TabIndex = 15;
            this.lblGroupMemo.Text = "备注";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(18, 54);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(53, 12);
            this.lblGroupName.TabIndex = 14;
            this.lblGroupName.Text = "分组名称";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(192, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 221);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGroupMemo
            // 
            this.txtGroupMemo.Location = new System.Drawing.Point(94, 89);
            this.txtGroupMemo.Multiline = true;
            this.txtGroupMemo.Name = "txtGroupMemo";
            this.txtGroupMemo.Size = new System.Drawing.Size(173, 110);
            this.txtGroupMemo.TabIndex = 10;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(94, 51);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(173, 21);
            this.txtGroupName.TabIndex = 9;
            // 
            // FormGroupDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblGroupMemo);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtGroupMemo);
            this.Controls.Add(this.txtGroupName);
            this.Name = "FormGroupDetail";
            this.Text = "分组详细信息";
            this.Load += new System.EventHandler(this.FormGroupDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblGroupMemo;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGroupMemo;
        private System.Windows.Forms.TextBox txtGroupName;
    }
}