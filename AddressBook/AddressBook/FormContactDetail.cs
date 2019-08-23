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
    public partial class FormContactDetail : Form
    {
        int id;

        public FormContactDetail()
        {
            InitializeComponent();
        }

        // 带参的构造函数
        public FormContactDetail(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        /// <summary>
        /// 绑定分组下拉框
        /// </summary>
        void FillGroup()
        {
            DataTable dt = new DataTable();
            dt = SqlDbHelper.ExecuteDataTable("GetAllContactGroup", CommandType.StoredProcedure);
            cboGroup.DisplayMember = "GroupName";
            cboGroup.ValueMember = "Id";
            cboGroup.DataSource = dt;
        }

        bool Check(string name, string phone, string email, string qq, string officePhone, string homePhone)
        {
            bool check = true;
            if (name == "")
            {
                MessageBox.Show("联系人姓名不能为空！");
                txtName.Focus();
                check = false;
            }
            if (!Utility.CheckMobilePhone(phone))
            {
                MessageBox.Show("手机号码不正确！");
                txtPhone.Focus();
                check = false;
            }
            if (!Utility.CheckEmail(email))
            {
                MessageBox.Show("Email格式不正确！");
                txtEmail.Focus();
                check = false;
            }
            if (!Utility.CheckQQ(qq))
            {
                MessageBox.Show("QQ号码不正确！");
                txtQQ.Focus();
                check = false;
            }
            if (!Utility.CheckPhone(officePhone))
            {
                MessageBox.Show("办公电话不正确！");
                txtOfficePhone.Focus();
                check = false;
            }
            if (!Utility.CheckPhone(homePhone))
            {
                MessageBox.Show("家庭电话不正确！");
                txtHomePhone.Focus();
                check = false;
            }
            return check;
        }

        private void FormContactDetail_Load(object sender, EventArgs e)
        {
            FillGroup();
            txtId.Text = id.ToString();
            SqlDataReader dr = null;
            try
            {
                SqlParameter[] para = 
                {
                    new SqlParameter("@Id", SqlDbType.Int, 4)
                };
                para[0].Value = id;
                dr = SqlDbHelper.ExecuteReader("GetContactById", CommandType.StoredProcedure, para);
                if (dr.Read())
                {
                    txtName.Text = dr["Name"].ToString();
                    txtPhone.Text = dr["Phone"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtQQ.Text = dr["QQ"].ToString();
                    txtWorkUnit.Text = dr["WorkUnit"].ToString();
                    txtOfficePhone.Text = dr["OfficePhone"].ToString();
                    txtHomeAddress.Text = dr["HomeAddress"].ToString();
                    txtHomePhone.Text = dr["HomePhone"].ToString();
                    txtMemo.Text = dr["Memo"].ToString();

                    cboGroup.SelectedValue = dr["GroupId"].ToString();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string qq = txtQQ.Text.Trim();
            string workUnit = txtWorkUnit.Text.Trim();
            string officePhone = txtOfficePhone.Text.Trim();
            string homeAddress = txtHomeAddress.Text.Trim();
            string homePhone = txtHomePhone.Text.Trim();
            string memo = txtMemo.Text.Trim();

            int groupId = Convert.ToInt32(cboGroup.SelectedValue);

            if (!Check(name, phone, email, qq, officePhone, homePhone))
                return;

            SqlParameter[] para = 
            {
                new SqlParameter("@Name", SqlDbType.NVarChar, 50),
                new SqlParameter("@Phone", SqlDbType.VarChar, 11),
                new SqlParameter("@Email", SqlDbType.NVarChar, 50),
                new SqlParameter("@QQ", SqlDbType.VarChar, 20),
                new SqlParameter("@WorkUnit", SqlDbType.NVarChar, 200),
                new SqlParameter("@OfficePhone", SqlDbType.VarChar, 20),
                new SqlParameter("@HomeAddress", SqlDbType.NVarChar, 200),
                new SqlParameter("@HomePhone", SqlDbType.VarChar, 20),
                new SqlParameter("@Memo", SqlDbType.NVarChar, 200),
                new SqlParameter("@GroupId", SqlDbType.Int, 4),
                new SqlParameter("@Id", SqlDbType.Int, 4)
            };
            para[0].Value = name;
            para[1].Value = phone;
            para[2].Value = email;
            para[3].Value = qq;
            para[4].Value = workUnit;
            para[5].Value = officePhone;
            para[6].Value = homeAddress;
            para[7].Value = homePhone;
            para[8].Value = memo;
            para[9].Value = groupId;
            para[10].Value = id;
            int rows = SqlDbHelper.ExecuteNonQuery("UpdateContact", CommandType.StoredProcedure, para);
            if (rows != 1)
                MessageBox.Show("更新失败！");
            else
                MessageBox.Show("更新成功！");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
