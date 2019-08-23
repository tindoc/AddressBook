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
    public partial class FormPwdChange : Form
    {
        public FormPwdChange()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOldPwd.Text.Trim() != UserHelper.password)
            {
                MessageBox.Show("原始密码错误！");
                txtOldPwd.Focus();
                return;
            }
            if (txtNewPwd.Text.Trim() == "")
            {
                MessageBox.Show("新密码不能为空，请输入！");
                txtNewPwd.Focus();
                return;
            }
            if (txtNewPwd.Text.Trim() != txtNewPwdAgain.Text.Trim())
            {
                MessageBox.Show("两次输入密码不一致，请重新输入！");
                txtNewPwdAgain.Focus();
                return;
            }
            string sql = "update [User] set Password=@Password where UserName=@userName";
            SqlParameter[] para = 
            {
                new SqlParameter("@Password", SqlDbType.VarChar, 50),
                new SqlParameter("@userName", SqlDbType.VarChar, 50)
            };
            para[0].Value = txtNewPwd.Text.Trim();
            para[1].Value = UserHelper.userName;
            int n = SqlDbHelper.ExecuteNonQuery(sql, CommandType.Text, para);
            if (n != 1)
                MessageBox.Show("密码修改失败！");
            else
            {
                MessageBox.Show("密码修改成功！");
                UserHelper.password = txtNewPwd.Text.Trim();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
