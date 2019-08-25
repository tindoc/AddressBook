using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SQLDAL
{
    public class BackupAndRestoreDb:IDAL.IBackupAndRestoreDb
    {
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="backupPath"></param>
        public void BackDb(string backupPath)
        {
            if (File.Exists(backupPath))
                File.Delete(backupPath);

            string sql = "backup database AddressList to disk=@backupPath";
            SqlParameter[] para =
            {
                new SqlParameter("@backupPath", SqlDbType.NVarChar, 200)
            };
            para[0].Value = backupPath;

            SqlDbHelper.ExecuteNonQuery(sql, para);
        }

        /// <summary>
        /// 恢复数据库
        /// </summary>
        /// <param name="restorePath"></param>
        public void RestoreDb(string restorePath)
        {
            string sql =
                    "Alter Database AddressList Set Offline with Rollback immediate;" +
                    "use master;" +
                    "restore database AddressList from disk=@restorePath With Replace;" +
                    "Alter Database AddressList Set OnLine With rollback Immediate";

            SqlParameter[] para = 
            {
                new SqlParameter("@restorePath", SqlDbType.NVarChar, 200)
            };
            para[0].Value = restorePath;

            SqlDbHelper.ExecuteNonQuery(sql, para);
        }
    }
}
