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
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                #region 普通
                //SqlCommand cmd = new SqlCommand(sqlstr, conn);
                //cmd.Parameters.AddWithValue("@id", id);
                //conn.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{
                //    txtGroupName.Text = dr["GroupName"].ToString();
                //    txtGroupMemo.Text = dr["Memo"].ToString();
                //}
                //dr.Close();
                #endregion 

                #region 使用存储过程
                SqlCommand cmd = new SqlCommand("GetGroupById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pGroupName = cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar, 50);
                pGroupName.Direction = ParameterDirection.Output;

                SqlParameter pMemo = cmd.Parameters.Add("@Memo", SqlDbType.NVarChar, 200);
                pMemo.Direction = ParameterDirection.Output;

                SqlParameter pReturn = new SqlParameter("@return", SqlDbType.Int);
                pReturn.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(pReturn);

                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                if (Convert.ToInt32(pReturn.Value) == 0)
                {
                    txtGroupName.Text = pGroupName.Value.ToString();
                    txtGroupMemo.Text = pMemo.Value.ToString();
                }
                else
                    MessageBox.Show("查询出错");
                #endregion
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text.Trim();
            if (CheckGroupName(groupName) == false)
                return;
            string memo = txtGroupMemo.Text.Trim();
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                string sql = "update ContactGroup set GroupName=@GroupName,Memo=@Memo where Id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@GroupName", groupName);
                cmd.Parameters.AddWithValue("@Memo", memo);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int n = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (n != 1)
                    MessageBox.Show("更新失败！");
                else
                    MessageBox.Show("更新成功！");
            }
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
