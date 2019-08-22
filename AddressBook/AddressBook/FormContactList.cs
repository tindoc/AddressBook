using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace AddressBook
{
    public partial class FormContactList : Form
    {
        SqlDataAdapter da;
        DataSet ds;

        /// <summary>
        /// DataGridView 数据的获取/更新
        /// </summary>
        public void Fill()
        {
            string sql = "select Contact.Id,Name,Phone,Email,QQ,GroupName from Contact,ContactGroup where Contact.GroupId=ContactGroup.Id";
            if (cboCondition.Text == "姓名")
                sql += " and Name like '%" + txtSearch.Text.Trim() + "%'";
            else if (cboCondition.Text == "手机")
                sql += " and Phone like '%" + txtSearch.Text.Trim() + "%'";
            sql += " order by Contact.Id desc";
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds);
                dgvContactList.DataSource = ds.Tables[0];
            }
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
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                string sql = string.Format("delete from Contact where Id={0}", id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                int n = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (n != 1)
                    MessageBox.Show("删除失败！");
                else
                    MessageBox.Show("删除成功！");

                Fill();
            }

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
