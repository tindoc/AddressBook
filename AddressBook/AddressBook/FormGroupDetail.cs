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
            txtId.Text = id.ToString();
            string sqlstr = "select * from ContactGroup where id = @id";
            SqlParameter[] para = {
                new SqlParameter("@id", SqlDbType.Int, 4)};
            para[0].Value = id;
            SqlDataReader dr = null;
            try
            {
                dr = SqlDbHelper.ExecuteReader(sqlstr, CommandType.Text, para);
                if (dr.Read())
                {
                    txtGroupName.Text = dr["GroupName"].ToString();
                    txtGroupMemo.Text = dr["Memo"].ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text.Trim();
            if (CheckGroupName(groupName) == false)
                return;
            string memo = txtGroupMemo.Text.Trim();
            string sql = "update ContactGroup set GroupName=@GroupName,Memo=@Memo where Id=@id";
            SqlParameter[] para = {
                new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
                new SqlParameter("@Memo", SqlDbType.NVarChar, 200),
                new SqlParameter("@id", SqlDbType.Int, 4)};
            para[0].Value = groupName;
            para[1].Value = memo;
            para[2].Value = id;
            int n = SqlDbHelper.ExecuteNonQuery(sql, CommandType.Text, para);
            if (n != 1)
                MessageBox.Show("更新失败！");
            else
                MessageBox.Show("更新成功！");
        }

        /// <summary>
        /// 判断输入的分组名称是否允许（非空且不可重复）,与FormGroupAdd中的略不同
        /// </summary>
        /// <param name="gourpName">分组名称</param>
        /// <returns>是否允许</returns>
        bool CheckGroupName(string groupName)
        {
            bool check = true;
            if (groupName == "")
            {
                MessageBox.Show("分组名称不能为空");
                txtGroupName.Focus();
                check = false;
            }
            return check;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
