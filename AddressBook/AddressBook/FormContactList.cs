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
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter();

            DataTable dt = new DataTable();
            if (cboCondition.Text == "姓名")
            {
                para[0].ParameterName = "@Name";
                para[0].SqlDbType = SqlDbType.NVarChar;
                para[0].Size = 50;
                para[0].Value = txtSearch.Text.Trim();
                dt = SqlDbHelper.ExecuteDataTable("GetContactListByName", CommandType.StoredProcedure, para);
            }
            else
            {
                para[0].ParameterName = "@Phone";
                para[0].SqlDbType = SqlDbType.VarChar;
                para[0].Size = 11;
                para[0].Value = txtSearch.Text.Trim();
                dt = SqlDbHelper.ExecuteDataTable("GetContactListByPhone", CommandType.StoredProcedure, para);
            }
            dgvContactList.DataSource = dt;
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

            SqlParameter[] para = {
                new SqlParameter("@Id", SqlDbType.Int, 4)};
            para[0].Value = id;
            int rows = SqlDbHelper.ExecuteNonQuery("DeleteContactById", CommandType.StoredProcedure, para);
            if (rows != 1)
                MessageBox.Show("删除失败！");
            else
                MessageBox.Show("删除成功！");

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
