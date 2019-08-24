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
    public partial class FormGroupDetail : Form
    {
        int id;

        public FormGroupDetail()
        {
            InitializeComponent();
        }

        // 带参构造函数
        public FormGroupDetail(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void FormGroupDetail_Load(object sender, EventArgs e)
        {
            BLL.ContactGroup bll = new BLL.ContactGroup();
            Model.ContactGroup model = bll.GetModel(id);

            if (model == null)
            {
                MessageBox.Show("数据出错");
                return;
            }
            else
            {
                txtGroupName.Text = model.GroupName;
                txtGroupMemo.Text = model.Memo;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Model.ContactGroup model = new Model.ContactGroup();
            model.Id = id;
            model.GroupName = txtGroupName.Text.Trim();
            model.Memo = txtGroupMemo.Text.Trim();

            BLL.ContactGroup bll = new BLL.ContactGroup();
            string msg = "";
            if (bll.Update(model, out msg))
                MessageBox.Show("更新成功");
            else
                MessageBox.Show(msg);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
