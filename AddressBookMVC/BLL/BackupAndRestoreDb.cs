using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BackupAndRestoreDb
    {
        //SQLDAL.BackupAndRestoreDb dal = new SQLDAL.BackupAndRestoreDb();
        //AccessDAL.BackupAndRestoreDb dal = new AccessDAL.BackupAndRestoreDb();
        IDAL.IBackupAndRestoreDb dal = DALFactory.DataAccess.CreateBackupAndRestoreDb();

        public void BackDb(string backupPath)
        {
            dal.BackDb(backupPath);
        }

        public void RestoreDb(string restorePath)
        {
            dal.RestoreDb(restorePath);
        }
    }
}
