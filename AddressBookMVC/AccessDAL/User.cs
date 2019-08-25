using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

namespace AccessDAL
{
    /// <summary>
    /// 数据访问类：User
    /// </summary>
    public partial class User:IDAL.IUser
    {
        public User() { }

        #region Method
        /// <summary>
        /// 判断用户名、密码是否正确
        /// </summary>
        /// <param name="userNmame"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public bool Login(string userName, string userPassword)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(*) from [User] ");
            sql.Append("where UserName=@UserName and Password=@Password");

            OleDbParameter[] para = 
            {
                new OleDbParameter("@UserName", OleDbType.VarChar, 50),
                new OleDbParameter("@Password", OleDbType.VarChar, 50)
            };
            para[0].Value = userName;
            para[1].Value = userPassword;

            int n = Convert.ToInt32(OleDbHelper.ExecuteScalar(sql.ToString(), para));   // 用的是 StringBuilder 生成的 sql，需要 toString()
            if (n == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.User model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update [User] set ");
            sql.Append("[Password]=@Password ");    // password 为 Access 保留字
            sql.Append("where UserName=@userName");

            OleDbParameter[] para = 
            {
                new OleDbParameter("@Password", OleDbType.VarChar, 50),
                new OleDbParameter("@userName", OleDbType.VarChar, 50)
            };
            para[0].Value = model.Password;
            para[1].Value = model.UserName;
            int n = OleDbHelper.ExecuteNonQuery(sql.ToString(), para);
            if (n == 1)
                return true;
            else
                return false;
        }
        #endregion Method
    }
}
