using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace AddressBook
{
    class DBHelper
    {
        public static string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        // 注意，即使 using System.Configuration; 依然无法使用 ConfigurationManager 类，还需要在解决方案资源管理器中本项目添加引用 System.configuration
        // 声明为 static 是因为可以直接使用 DBHelper.connString 直接访问，不需要生成类的对象
    }
}
