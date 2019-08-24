using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Common;

namespace BLL
{
    public class Contact
    {
        SQLDAL.Contact dal = new SQLDAL.Contact();

        public int GetContactCountByGroupId(int groupId)
        {
            return dal.GetContactCountByGroupId(groupId);
        }

        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public bool CheckModel(Model.Contact model, out string msg)
        {
            bool check = true;
            msg = "";

            if (model.Name == "")
            {
                msg = "联系人姓名不能为空！";
                check = false;
                return check;
            }
            if (!Utility.CheckMobilePhone(model.Phone)) // 需要添加引用和using 命名空间
            {
                msg = "手机号码不正确！";
                check = false;
                return check;
            }
            if (!Utility.CheckEmail(model.Email))
            {
                msg = "Email 格式不正确!";
                check = false;
                return check;
            }
            if (!Utility.CheckQQ(model.QQ))
            {
                msg = "QQ 号码不正确！";
                check = false;
                return check;
            }
            if (!Utility.CheckPhone(model.OfficePhone))
            {
                msg = "办公电话不正确！";
                check = false;
                return check;
            }
            if (!Utility.CheckPhone(model.HomePhone))
            {
                msg = "家庭电话不正确！";
                check = false;
                return check;
            }
            return check;
        }

        public bool Add(Model.Contact model, out string msg)
        {
            if (!CheckModel(model, out msg))
                return false;
            else
                return dal.Add(model);
        }

        public bool Delete(int Id)
        {
            return dal.Delete(Id);
        }

        public bool Update(Model.Contact model, out string msg)
        {
            if (!CheckModel(model, out msg))
                return false;
            else
                return dal.Update(model);
        }

        public Model.Contact GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
    }
}
