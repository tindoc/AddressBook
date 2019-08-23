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
            string sql = "select * from ContactGroup";
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                //SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd = new SqlCommand("GetAllContactGroup", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds);
                cboGroup.DisplayMember = "GroupName";
                cboGroup.ValueMember = "Id";
                cboGroup.DataSource = ds.Tables[0];
            }
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
            string sql = string.Format("select * from Contact where id={0}", id);
            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                //SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd = new SqlCommand("GetContactById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
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

            using (SqlConnection conn = new SqlConnection(DBHelper.connString))
            {
                #region 普通
                //string sql = string.Format("update Contact set Name='{0}',Phone='{1}',Email='{2}',QQ='{3}',WorkUnit='{4}',OfficePhone='{5}',HomeAddress='{6}',HomePhone='{7}',Memo='{8}',GroupId='{9}' where Id = {10}",
                //    name, phone, email, qq, workUnit, officePhone, homeAddress, homePhone, memo, groupId, id);
                //SqlCommand cmd = new SqlCommand(sql, conn);
                #endregion

                #region 使用存储过程
                SqlCommand cmd = new SqlCommand("UpdateContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@QQ", qq);
                cmd.Parameters.AddWithValue("@WorkUnit", workUnit);
                cmd.Parameters.AddWithValue("@OfficePhone", officePhone);
                cmd.Parameters.AddWithValue("@HomeAddress", homeAddress);
                cmd.Parameters.AddWithValue("@HomePhone", homePhone);
                cmd.Parameters.AddWithValue("@Memo", memo);
                cmd.Parameters.AddWithValue("@GroupId", groupId);
                cmd.Parameters.AddWithValue("@Id", id);
                #endregion

                conn.Open();
                int n = Convert.ToInt32(cmd.ExecuteNonQuery());
                if (n != 1)
                    MessageBox.Show("更新失败！");
                else
                    MessageBox.Show("更新成功！");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
