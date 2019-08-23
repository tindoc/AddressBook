using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

namespace AddressBook
{
    public partial class FormDB : Form
    {
        string backupPath = "";
        string restorePath = "";

        public FormDB()
        {
            InitializeComponent();
        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            sfdlgBackup.FilterIndex = 1;
            sfdlgBackup.FileName = "";
            sfdlgBackup.Filter = "Bak Files (*.bak)|*.bak";
            if (sfdlgBackup.ShowDialog() == DialogResult.OK)
            {
                txtBackup.Text = sfdlgBackup.FileName.ToString();
                txtBackup.ReadOnly = true;
            }
            backupPath = txtBackup.Text.Trim();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (backupPath == "")
            {
                MessageBox.Show("请先选择数据库备份路径","提示");
                return;
            }
            
            SqlConnection conn = new SqlConnection(DBHelper.connString);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (File.Exists(backupPath))    // 需要引用 System.IO 类
                    File.Delete(backupPath);

                string sql = string.Format("backup database AddressList to disk='{0}'", backupPath);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                cmd.ExecuteNonQuery();
                MessageBox.Show("数据库备份成功");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnRestorePath_Click(object sender, EventArgs e)
        {
            ofdlgRestore.FilterIndex = 1;
            ofdlgRestore.FileName = "";
            ofdlgRestore.Filter = "Bak Files (*.bak)|*.bak";
            if (ofdlgRestore.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = ofdlgRestore.FileName.ToString();
                txtRestore.ReadOnly = true;
            }
            restorePath = txtRestore.Text.Trim();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (restorePath == "")
            {
                MessageBox.Show("请先选择数据库恢复路径", "提示");
                return;
            }

            SqlConnection conn = new SqlConnection(DBHelper.connString);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string sql = string.Format(
                    "Alter Database AddressList Set Offline with Rollback immediate;" +
                    "use master;" +
                    "restore database AddressList from disk='{0}' With Replace;" +
                    "Alter Database AddressList Set OnLine With rollback Immediate", restorePath);

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("数据库恢复成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
