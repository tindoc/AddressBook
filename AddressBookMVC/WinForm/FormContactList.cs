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
    public partial class FormContactList : Form
    {
        BLL.Contact bll = new BLL.Contact();

        /// <summary>
        /// DataGridView 数据的获取/更新
        /// </summary>
        public void Fill()
        {
            string strWhere = "";
            if (cboCondition.Text == "姓名")
                strWhere = "Name like '%" + txtSearch.Text.Trim() + "%'";
            if (cboCondition.Text == "手机")
                strWhere = "Phone like '%" + txtSearch.Text.Trim() + "%'";
            
            dgvContactList.DataSource = bll.GetList(strWhere);
        }

        public FormContactList()
        {
            InitializeComponent();
        }

        private void FormContactList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormContactAdd f = new FormContactAdd();
            f.ShowDialog();
            Fill();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)dgvContactList.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }
            if (MessageBox.Show("确定要删除吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            if (bll.Delete(id))
                MessageBox.Show("删除成功！");
            else
                MessageBox.Show("删除失败！");

            Fill();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = (int)dgvContactList.CurrentRow.Cells[0].Value;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("请选择有效数据行！");
                return;
            }
            FormContactDetail f = new FormContactDetail(id);
            f.ShowDialog();
            Fill();
        }

        private void dgvContactList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnModify_Click(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
