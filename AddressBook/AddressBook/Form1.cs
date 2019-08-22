using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"";
            SqlConnection connection = new SqlConnection(connString);

            //using (SqlConnection connection = new SqlConnection(connString))
            //{
            //    connection.Open();
            //    MessageBox.Show("打开数据库成功");
            //}

            try
            {
                connection.Open();
                MessageBox.Show("打开数据库成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
                MessageBox.Show("关闭数据库成功");
            }
        }
    }
}
