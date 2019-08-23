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
            //using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            //{
            //    da = new SqlDataAdapter(sql, conn);
            //    ds = new DataSet();
            //    da.Fill(ds);
            //    dgvGroupList.DataSource = ds.Tables[0];
            //}
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql);
            dgvGroupList.DataSource = dt;
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

            string sql = "select count(*) from Contact where GroupId = @id";
            SqlParameter[] para = {
                new SqlParameter("@id",SqlDbType.Int, 4)};
            para[0].Value = id;
            int n = int.Parse(SqlDbHelper.ExecuteScalar(sql, CommandType.Text, para).ToString());
            if (n >= 1)
            {
                MessageBox.Show("该分组下存在联系人信息，不允许删除！");
                return;
            }
            string sql_2 = "delete from ContactGroup where Id = @id";
            SqlParameter[] para_2 = {
                new SqlParameter("@id", SqlDbType.Int, 4)};
            para_2[0].Value = id;
            int rows = SqlDbHelper.ExecuteNonQuery(sql_2, CommandType.Text, para_2);
            if (rows != 1)
            {
                MessageBox.Show("删除失败！");
            }
            else
            {
                MessageBox.Show("删除成功！");
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
