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
            #region 使用 SqlDbHelper 类实现登录
            string userName = txtUserName.Text.Trim();
            string userPassword = txtUserPassword.Text.Trim();

            if (userName == "" || userPassword == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                txtUserName.Focus();
                return;
            }
            string sql = "select count(*) from [User] where UserName=@UserName and Password=@Password";
            SqlParameter[] para = {
                new SqlParameter("@UserName", SqlDbType.VarChar, 50),
                new SqlParameter("@Password", SqlDbType.VarChar, 50)};
            para[0].Value = userName;
            para[1].Value = userPassword;
            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(sql, CommandType.Text, para));
            if (n ==1)
            {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
