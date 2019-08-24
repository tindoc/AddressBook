using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace WinForm
{
    public partial class FormDB : Form
    {
        string backupPath = "";
        string restorePath = "";
        BLL.BackupAndRestoreDb bll = new BLL.BackupAndRestoreDb();

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
                MessageBox.Show("请先选择数据库备份路径", "提示");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (File.Exists(backupPath))    // 需要引用 System.IO 类
                    File.Delete(backupPath);

                bll.BackDb(backupPath);
                MessageBox.Show("数据库备份成功");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
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

            try
            {
                this.Cursor = Cursors.WaitCursor;
                bll.RestoreDb(restorePath);
                MessageBox.Show("数据库恢复成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
