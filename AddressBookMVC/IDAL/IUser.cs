using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IUser
    {
        /// <summary>
        /// 判断用户名、密码是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        bool Login(string userName, string userPassword);

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.User model);
    }
}
