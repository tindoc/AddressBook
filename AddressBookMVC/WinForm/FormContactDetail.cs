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
    public partial class FormContactDetail : Form
    {
        int id;

        public FormContactDetail()
        {
            InitializeComponent();
        }

        // 带参的构造函数
        public FormContactDetail(int id)
        {
            this.id = id;
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

        private void FormContactDetail_Load(object sender, EventArgs e)
        {
            FillGroup();
            txtId.Text = id.ToString();

            BLL.Contact bll = new BLL.Contact();
            Model.Contact model = bll.GetModel(id);

            if (model == null)
            {
                MessageBox.Show("数据查询出错");
                return;
            }
            else
            {
                txtName.Text = model.Name;
                txtPhone.Text = model.Phone;
                txtEmail.Text = model.Email;
                txtQQ.Text = model.QQ;
                txtWorkUnit.Text = model.WorkUnit;
                txtOfficePhone.Text = model.OfficePhone;
                txtHomeAddress.Text = model.HomeAddress;
                txtHomePhone.Text = model.HomePhone;
                txtMemo.Text = model.Memo;

                cboGroup.SelectedValue = model.GroupId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Model.Contact model = new Model.Contact();

            model.Id = id;
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

            BLL.Contact dll = new BLL.Contact();
            string msg = "";
            if (dll.Update(model, out msg))
                MessageBox.Show("更新成功！");
            else
                MessageBox.Show(msg);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
