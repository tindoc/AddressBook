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
    public partial class FormGroupList : Form
    {
        BLL.ContactGroup bll = new BLL.ContactGroup();

        public FormGroupList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DataGridView 数据获取/更新
        /// </summary>
        public void Fill()
        {
            dgvGroupList.DataSource = bll.GetList("");
        }

        private void FormContactList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormGroupAdd f = new FormGroupAdd();
            f.ShowDialog();
            Fill();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)dgvGroupList.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }
            if (MessageBox.Show("确定要删除吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            if (bll.Delete(id))
                MessageBox.Show("删除成功");
            else
                MessageBox.Show("该分组下存在联系人信息，不允许删除！");

            Fill();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)dgvGroupList.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }

            FormGroupDetail f = new FormGroupDetail(id);
            f.ShowDialog();
            Fill();
        }

        private void dgvGroupList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnModify_Click(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
