using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace AddressBook
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "" || txtUserPassword.Text.Trim() == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                txtUserName.Focus();
                return;
            }

            string connString = DBHelper.connString;
            string sqlStr = string.Format("select count(*) from [User] where UserName = '{0}' and Password = '{1}'",
                txtUserName.Text.Trim(),txtUserPassword.Text.Trim());   // 这是不使用参数构建 SQL 语句。其中，User 是 数据库的保留字要加方括号

            using (SqlConnection conn = new SqlConnection(connString))
            {
                #region 使用 SqlCommand 对象来实现登录
                //SqlCommand cmd = new SqlCommand(sqlStr, conn);
                //conn.Open();

                //int result = Convert.ToInt32(cmd.ExecuteScalar());   // SqlCommand.ExecuteScalar 执行查询，返回查询结果中第一行第一列的值，但类型为 object
                //if (result == 1)
                //{
                //    //MessageBox.Show("登录成功！");
                //    UserHelper.userName = txtUserName.Text.Trim();
                //    UserHelper.password = txtUserPassword.Text.Trim();
                //    this.Hide();
                //    FormMain f = new FormMain();  // 跳转到主窗体
                //    f.Show();
                //}
                //else
                //{
                //    MessageBox.Show("用户名或密码错误，请重新输入！", "错误");
                //    txtUserName.Text = txtUserPassword.Text = "";
                //    txtUserName.Focus();
                //}
                #endregion

                #region 使用 SqlDataReader 对象来实现登录 */
                //sqlStr = string.Format("select * from [User] where UserName = '{0}' and Password = '{1}'",
                //txtUserName.Text.Trim(), txtUserPassword.Text.Trim());  // 注意 sql 的修改
                //SqlCommand cmd = new SqlCommand(sqlStr, conn);
                //conn.Open();

                //SqlDataReader sdr = cmd.ExecuteReader();
                //if (sdr.Read())
                //{
                //    //MessageBox.Show("登录成功！");
                //    UserHelper.userName = txtUserName.Text.Trim();
                //    UserHelper.password = txtUserPassword.Text.Trim();
                //    this.Hide();
                //    FormMain f = new FormMain();  // 跳转到主窗体
                //    f.Show();
                //}
                //else
                //{
                //    MessageBox.Show("用户名或密码错误，请重新输入！", "错误");
                //    txtUserName.Text = txtUserPassword.Text = "";
                //    txtUserName.Focus();
                //}
                //sdr.Close();
                #endregion

                #region 使用SqlDataAdapter 对象来实现登录
                sqlStr = string.Format("select * from [User] where UserName = '{0}' and Password = '{1}'",
                txtUserName.Text.Trim(), txtUserPassword.Text.Trim());  // 注意 sql 的修改
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    //MessageBox.Show("登录成功！");
                    UserHelper.userName = txtUserName.Text.Trim();
                    UserHelper.password = txtUserPassword.Text.Trim();
                    this.Hide();
                    FormMain f = new FormMain();  // 跳转到主窗体
                    f.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入！", "错误");
                    txtUserName.Text = txtUserPassword.Text = "";
                    txtUserName.Focus();
                }
                #endregion
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
