using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace SQLDAL
{
    /// <summary>
    /// 数据访问类：ContactGroup
    /// </summary>
    public partial class ContactGroup:IDAL.IContactGroup
    {
        public ContactGroup() { }

        #region Method
        /// <summary>
        /// 根据查询条件获取分组列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select Id,GroupName,Memo ");
            sql.Append("from ContactGroup ");
            if (strWhere.Trim() != "")
                sql.Append("where " + strWhere);
            return SqlDbHelper.ExecuteDataTable(sql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Model.ContactGroup model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into ContactGroup ");
            sql.Append("values(@GroupName,@Memo);");
            sql.Append("select @@IDENTITY");    // 得到上一次插入记录时自动产生的ID

            SqlParameter[] para = 
            {
                new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
                new SqlParameter("@Memo", SqlDbType.NVarChar, 200)
            };
            para[0].Value = model.GroupName;
            para[1].Value = model.Memo;
            int n = SqlDbHelper.ExecuteNonQuery(sql.ToString(), para);

            if (n > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据分组编号获取分组信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.ContactGroup GetModel(int Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select top 1 Id,GroupName,Memo from ContactGroup ");
            sql.Append("where Id = @id");

            SqlParameter[] para = {
                new SqlParameter("@id", SqlDbType.Int, 4)};
            para[0].Value = Id;

            Model.ContactGroup model = new Model.ContactGroup();
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), para);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Id"] != null && dt.Rows[0]["Id"].ToString() != "")
                    model.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                if (dt.Rows[0]["GroupName"] != null && dt.Rows[0]["GroupName"].ToString() != "")
                    model.GroupName = dt.Rows[0]["GroupName"].ToString();
                if (dt.Rows[0]["Memo"] != null && dt.Rows[0]["Memo"].ToString() != "")
                    model.Memo = dt.Rows[0]["Memo"].ToString();
                return model;
            }
            else
                return null;
        }

        /// <summary>
        /// 根据分组名称获取分组信息
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public Model.ContactGroup GetModel(string groupName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select top 1 Id,GroupName,Memo from ContactGroup ");
            sql.Append("where GroupName = @GroupName");

            SqlParameter[] para = {
                new SqlParameter("@GroupName", SqlDbType.NVarChar, 50)};
            para[0].Value = groupName;

            Model.ContactGroup model = new Model.ContactGroup();
            DataTable dt = SqlDbHelper.ExecuteDataTable(sql.ToString(), para);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Id"] != null && dt.Rows[0]["Id"].ToString() != "")
                    model.Id = int.Parse(dt.Rows[0]["Id"].ToString());
                if (dt.Rows[0]["GroupName"] != null && dt.Rows[0]["GroupName"].ToString() != "")
                    model.GroupName = dt.Rows[0]["GroupName"].ToString();
                if (dt.Rows[0]["Memo"] != null && dt.Rows[0]["Memo"].ToString() != "")
                    model.Memo = dt.Rows[0]["Memo"].ToString();
                return model;
            }
            else
                return null;
        }

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(int Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from ContactGroup ");
            sql.Append("where Id=@Id");

            SqlParameter[] para = 
            {
                new SqlParameter("@id",SqlDbType.Int, 4)
            };
            para[0].Value = Id;
            int n = SqlDbHelper.ExecuteNonQuery(sql.ToString(), para);
            if (n > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新分组信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.ContactGroup model)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("update ContactGroup set ");
            sql.Append("GroupName=@GroupName,Memo=@Memo ");
            sql.Append("where Id=@Id");

            SqlParameter[] para = {
                new SqlParameter("@GroupName", SqlDbType.NVarChar, 50),
                new SqlParameter("@Memo", SqlDbType.NVarChar, 200),
                new SqlParameter("@id", SqlDbType.Int, 4)};
            para[0].Value = model.GroupName;
            para[1].Value = model.Memo;
            para[2].Value = model.Id;

            int n = SqlDbHelper.ExecuteNonQuery(sql.ToString(), para);
            if (n > 0)
                return true;
            else
                return false;
        }
        #endregion Method
    }
}
