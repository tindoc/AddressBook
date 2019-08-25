using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace IDAL
{
    public interface IContactGroup
    {
        /// <summary>
        /// 根据查询条件获取分组列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable GetList(string strWhere);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(Model.ContactGroup model);

        /// <summary>
        /// 根据分组编号，获取分组信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Model.ContactGroup GetModel(int id);

        /// <summary>
        /// 根据分组名称，获取分组信息
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        Model.ContactGroup GetModel(string groupName);

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(int Id);

        /// <summary>
        /// 更新分组信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.ContactGroup model);
    }
}
