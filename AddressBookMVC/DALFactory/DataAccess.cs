using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Reflection;

namespace DALFactory
{
    sealed public class DataAccess  // sealed 关键字，说明其他类不能继承自本类
    {
        private static readonly string AssemblyName = ConfigurationManager.AppSettings["DAL"];

        public static IDAL.IUser CreateUser()
        {
            string className = AssemblyName + ".User";

            return (IDAL.IUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IDAL.IContact CreateContact()
        {
            string className = AssemblyName + ".Contact";

            return (IDAL.IContact)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IDAL.IContactGroup CreateContactGroup()
        {
            string className = AssemblyName + ".ContactGroup";

            return (IDAL.IContactGroup)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IDAL.IBackupAndRestoreDb CreateBackupAndRestoreDb()
        {
            string className = AssemblyName + ".BackupAndRestoreDb";

            return (IDAL.IBackupAndRestoreDb)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
