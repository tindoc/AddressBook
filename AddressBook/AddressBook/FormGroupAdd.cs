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
    public partial class FormGroupAdd : Form
    {
        public FormGroupAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 判断输入的分组名称是否允许（非空且不可重复）
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
            else
            {
                string sql = "select count(*) from ContactGroup where GroupName = @GroupName";
                SqlParameter[] para = {
                    new SqlParameter("@GroupName", SqlDbType.NVarChar, 50)};
                para[0].Value = groupName;
                int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(sql, CommandType.Text, para));
                if (n >= 1)
                {
                    MessageBox.Show("分组名称重复，请修改！");
                    txtGroupName.Focus();
                    check = false;
                }
            }
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text.Trim();
            if (CheckGroupName(groupName) == false)
            {
                return;
            }
            string memo = txtGroupMemo.Text.Trim();

            string sql = "insert into ContactGroup values(@GroupName,@Memo)";
            SqlParameter[] para = {
                new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
                new SqlParameter("@Memo", SqlDbType.NVarChar, 200)};
            para[0].Value = groupName;
            para[1].Value = memo;
            int n = SqlDbHelper.ExecuteNonQuery(sql, CommandType.Text, para);

            if (n != 1)
            {
                MessageBox.Show("添加分组失败！");
            }
            else
            {
                MessageBox.Show("添加分组成功！");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
