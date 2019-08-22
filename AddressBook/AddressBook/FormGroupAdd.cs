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
                using (SqlConnection conn = new SqlConnection(DBHelper.connString))
                {
                    string sql = string.Format("select count(*) from ContactGroup where GroupName = '{0}'", groupName);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result >= 1)
                    {
                        MessageBox.Show("分组名称重复，请修改！");
                        txtGroupName.Focus();
                        check = false;
                    }
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
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                string sql = string.Format("insert into ContactGroup values('{0}','{1}')", groupName, memo);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (result != 1)
                {
                    MessageBox.Show("添加分组失败！");
                }
                else
                {
                    MessageBox.Show("添加分组成功！");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
