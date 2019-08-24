using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;
using System.IO;

namespace AccessDAL
{
    public class BackupAndRestoreDb
    {
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="backupPath"></param>
        public void BackDb(string backupPath)
        {
            if (File.Exists(backupPath))
                File.Delete(backupPath);

            File.Copy(System.Configuration.ConfigurationManager.AppSettings["DbPath"], backupPath, true);
        }

        /// <summary>
        /// 恢复数据库
        /// </summary>
        /// <param name="restorePath"></param>
        public void RestoreDb(string restorePath)
        {
            File.Copy(restorePath, System.Configuration.ConfigurationManager.AppSettings["DbPath"], true);
        }
    }
}
