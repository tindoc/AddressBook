using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace BLL
{
    public class ContactGroup
    {
        //SQLDAL.ContactGroup group = new SQLDAL.ContactGroup();
        AccessDAL.ContactGroup group = new AccessDAL.ContactGroup();

        public DataTable GetList(string strWhere)
        {
            return group.GetList(strWhere);
        }

        public Model.ContactGroup GetModel(string groupName)
        {
            return group.GetModel(groupName);
        }

        public Model.ContactGroup GetModel(int id)
        {
            return group.GetModel(id);
        }

        /// <summary>
        /// 检查分组名称是否为空
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CheckModel(Model.ContactGroup model, out string msg)
        {
            bool check = true;
            msg = "";

            if (model.GroupName == "")
            {
                msg = "分组名称不能为空";
                check = false;
            }

            return check;
        }

        public bool Add(Model.ContactGroup model, out string msg)
        {
            if (!CheckModel(model, out msg))
                return false;
            else
            {
                Model.ContactGroup modelcheck = GetModel(model.GroupName);
                if (modelcheck != null)
                {
                    msg = "分组名称重复";
                    return false;
                }
                else
                    return group.Add(model);
            }
        }

        public bool Delete(int Id)
        {
            //SQLDAL.Contact contact = new SQLDAL.Contact();
            AccessDAL.Contact contact = new AccessDAL.Contact();
            int count = contact.GetContactCountByGroupId(Id);
            if (count > 0)
                return false;   // 判断该分组下是否存在联系人
            else
                return group.Delete(Id);
        }

        public bool Update(Model.ContactGroup model, out string msg)
        {
            if (!CheckModel(model, out msg))
                return false;
            else
                return group.Update(model);
        }
    }
}
