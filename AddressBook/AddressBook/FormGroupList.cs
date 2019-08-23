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
    public partial class FormGroupList : Form
    {
        SqlDataAdapter da;
        DataSet ds;

        public FormGroupList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DataGridView 数据获取/更新
        /// </summary>
        public void Fill()
        {
            string sql = "select Id,GroupName,Memo from ContactGroup order by Id desc";
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds);
                dgvGroupList.DataSource = ds.Tables[0];
            }
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

            // 若分组下存在联系人信息，不允许删除
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                string sql = "select count(*) from Contact where GroupId = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result >= 1)
                {
                    MessageBox.Show("该分组下存在联系人信息，不允许删除！");
                    return;
                }
            }

            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                string sql = "delete from ContactGroup where Id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (result != 1)
                {
                    MessageBox.Show("删除失败！");
                }
                else
                {
                    MessageBox.Show("删除成功！");
                }
            }
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
