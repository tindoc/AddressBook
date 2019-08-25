using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface IBackupAndRestoreDb
    {
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="backupPath"></param>
        void BackDb(string backupPath);

        /// <summary>
        /// 恢复数据库
        /// </summary>
        /// <param name="restorePath"></param>
        void RestoreDb(string restorePath);
    }
}
