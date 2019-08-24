using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtUserPassword.Text.Trim();

            if (userName == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                txtUserName.Focus();
                return;
            }
            else
            {
                BLL.User user = new BLL.User();
                if (user.Login(userName, password))
                {
                    UserHelper.userName = txtUserName.Text.Trim();
                    UserHelper.password = txtUserPassword.Text.Trim();
                    
                    this.Hide();
                    FormMain f = new FormMain();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入！", "错误");
                    txtUserName.Text = "";
                    txtUserPassword.Text = "";
                    txtUserName.Focus();
                }
            }
        }
    }
}
