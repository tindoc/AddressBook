using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

namespace AccessDAL
{
    /// <summary>
    /// 数据访问类：Contact
    /// </summary>
    public class Contact:IDAL.IContact
    {
        public Contact() { }

        #region Method
        /// <summary>
        /// 根据分组编号获取该分组下的联系人数量
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public int GetContactCountByGroupId(int groupId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from Contact ");
            sql.Append("where GroupId=@GroupId");

            OleDbParameter[] para = 
            {
                new OleDbParameter("@GroupId", OleDbType.Integer, 4)
            };
            para[0].Value = groupId;
            return int.Parse(OleDbHelper.ExecuteScalar(sql.ToString(), para).ToString());
        }

        /// <summary>
        /// 根据查询条件获取联系人列表
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Contact.Id,Name,Phone,Email,QQ,GroupName from Contact,ContactGroup where Contact.GroupId=ContactGroup.Id ");
            if (strWhere.Trim() != "")
                sql.Append("and " + strWhere);
            sql.Append(" order by Contact.Id desc");
            return OleDbHelper.ExecuteDataTable(sql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.Contact model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into Contact( ");
            sql.Append("Name,Phone,Email,QQ,WorkUnit,OfficePhone,HomeAddress,HomePhone,[Memo],GroupId) ");
            sql.Append("values(@Name,@Phone,@Email,@QQ,@WorkUnit,@OfficePhone,@HomeAddress,@HomePhone,@Memo,@GroupId)");

            OleDbParameter[] para = 
            {
                new OleDbParameter("@Name", OleDbType.VarChar, 50),
                new OleDbParameter("@Phone", OleDbType.VarChar, 11),
                new OleDbParameter("@Email", OleDbType.VarChar, 50),
                new OleDbParameter("@QQ", OleDbType.VarChar, 20),
                new OleDbParameter("@WorkUnit", OleDbType.VarChar, 200),
                new OleDbParameter("@OfficePhone", OleDbType.VarChar, 20),
                new OleDbParameter("@HomeAddress", OleDbType.VarChar, 200),
                new OleDbParameter("@HomePhone", OleDbType.VarChar, 20),
                new OleDbParameter("@Memo", OleDbType.VarChar, 200),
                new OleDbParameter("@GroupId", OleDbType.Integer, 4)
            };
            para[0].Value = model.Name;
            para[1].Value = model.Phone;
            para[2].Value = model.Email;
            para[3].Value = model.QQ;
            para[4].Value = model.WorkUnit;
            para[5].Value = model.OfficePhone;
            para[6].Value = model.HomeAddress;
            para[7].Value = model.HomePhone;
            para[8].Value = model.Memo;
            para[9].Value = model.GroupId;

            int n = OleDbHelper.ExecuteNonQuery(sql.ToString(), para);
            if (n > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(int Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Contact ");
            sql.Append("where Id=@Id");

            OleDbParameter[] para = 
            {
                new OleDbParameter("@Id", OleDbType.Integer, 4)
            };
            para[0].Value = Id;

            int n = OleDbHelper.ExecuteNonQuery(sql.ToString(), para);
            if (n > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.Contact model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update Contact set ");
            sql.Append("Name=@Name,Phone=@Phone,Email=@Email,QQ=@QQ,WorkUnit=@WorkUnit,OfficePhone=@OfficePhone,HomeAddress=@HomeAddress,HomePhone=@HomePhone,[Memo]=@Memo,GroupId=@GroupId ");
            sql.Append("where Id=@Id");

            OleDbParameter[] para = 
            {
                new OleDbParameter("@Name", OleDbType.VarChar, 50),
                new OleDbParameter("@Phone", OleDbType.VarChar, 11),
                new OleDbParameter("@Email", OleDbType.VarChar, 50),
                new OleDbParameter("@QQ", OleDbType.VarChar, 20),
                new OleDbParameter("@WorkUnit", OleDbType.VarChar, 200),
                new OleDbParameter("@OfficePhone", OleDbType.VarChar, 20),
                new OleDbParameter("@HomeAddress", OleDbType.VarChar, 200),
                new OleDbParameter("@HomePhone", OleDbType.VarChar, 20),
                new OleDbParameter("@Memo", OleDbType.VarChar, 200),
                new OleDbParameter("@GroupId", OleDbType.Integer, 4),
                new OleDbParameter("@Id", OleDbType.Integer, 4)
            };
            para[0].Value = model.Name;
            para[1].Value = model.Phone;
            para[2].Value = model.Email;
            para[3].Value = model.QQ;
            para[4].Value = model.WorkUnit;
            para[5].Value = model.OfficePhone;
            para[6].Value = model.HomeAddress;
            para[7].Value = model.HomePhone;
            para[8].Value = model.Memo;
            para[9].Value = model.GroupId;
            para[10].Value = model.Id;

            int n = OleDbHelper.ExecuteNonQuery(sql.ToString(), para);
            if (n > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据联系人编号获取联系人信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.Contact GetModel(int Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select top 1 Id,Name,Phone,Email,QQ,WorkUnit,OfficePhone,HomeAddress,HomePhone,[Memo],GroupId from Contact ");
            sql.Append("where Id=@Id");

            OleDbParameter[] para = 
            {
                new OleDbParameter("@Id", OleDbType.Integer, 4)
            };
            para[0].Value = Id;

            Model.Contact model = new Model.Contact();
            DataTable dt = OleDbHelper.ExecuteDataTable(sql.ToString(), para);

            if (dt.Rows.Count > 0)
            {
                if (CheckDataTableCell(dt, 0, "Id"))
                    model.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                if (CheckDataTableCell(dt, 0, "Name"))
                    model.Name = dt.Rows[0]["Name"].ToString();
                if (CheckDataTableCell(dt, 0, "Phone"))
                    model.Phone = dt.Rows[0]["Phone"].ToString();
                if (CheckDataTableCell(dt, 0, "Email"))
                    model.Email = dt.Rows[0]["Email"].ToString();
                if (CheckDataTableCell(dt, 0, "QQ"))
                    model.QQ = dt.Rows[0]["QQ"].ToString();
                if (CheckDataTableCell(dt, 0, "WorkUnit"))
                    model.WorkUnit = dt.Rows[0]["WorkUnit"].ToString();
                if (CheckDataTableCell(dt, 0, "OfficePhone"))
                    model.OfficePhone = dt.Rows[0]["OfficePhone"].ToString();
                if (CheckDataTableCell(dt, 0, "HomeAddress"))
                    model.HomeAddress = dt.Rows[0]["HomeAddress"].ToString();
                if (CheckDataTableCell(dt, 0, "HomePhone"))
                    model.HomePhone = dt.Rows[0]["HomePhone"].ToString();
                if (CheckDataTableCell(dt, 0, "Memo"))
                    model.Memo = dt.Rows[0]["Memo"].ToString();
                if (CheckDataTableCell(dt, 0, "GroupId"))
                    model.GroupId = int.Parse(dt.Rows[0]["GroupId"].ToString());

                return model;
            }
            else
                return null;
        }

        private bool CheckDataTableCell(DataTable dt, int row, string column)
        {
            if (dt.Rows[row][column] != null && dt.Rows[row][column].ToString() != "")
                return true;
            else
                return false;
        }
        #endregion
    }
}
