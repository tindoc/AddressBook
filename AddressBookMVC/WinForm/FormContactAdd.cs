using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FormContactAdd : Form
    {
        public FormContactAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定分组下拉框
        /// </summary>
        void FillGroup()
        {
            BLL.ContactGroup group = new BLL.ContactGroup();

            cboGroup.DisplayMember = "GroupName";
            cboGroup.ValueMember = "Id";
            cboGroup.DataSource = group.GetList("");
        }

        private void FormContactAdd_Load(object sender, EventArgs e)
        {
            FillGroup();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Model.Contact model = new Model.Contact();

            model.Name = txtName.Text.Trim();
            model.Phone = txtPhone.Text.Trim();
            model.Email = txtEmail.Text.Trim();
            model.QQ = txtQQ.Text.Trim();
            model.WorkUnit = txtWorkUnit.Text.Trim();
            model.OfficePhone = txtOfficePhone.Text.Trim();
            model.HomeAddress = txtHomeAddress.Text.Trim();
            model.HomePhone = txtHomePhone.Text.Trim();
            model.Memo = txtMemo.Text.Trim();
            model.GroupId = Convert.ToInt32(cboGroup.SelectedValue);

            BLL.Contact bll = new BLL.Contact();
            string msg = "";
            if (bll.Add(model, out msg))
                MessageBox.Show("添加联系人成功！");
            else
                MessageBox.Show(msg);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
