using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace IDAL
{
    public interface IContact
    {
        /// <summary>
        /// 根据分组编号，获取该分组下的联系人数量
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        int GetContactCountByGroupId(int groupId);

        /// <summary>
        /// 根据查询条件，获取联系人列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable GetList(string strWhere);

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(Model.Contact model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(int Id);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Model.Contact model);

        /// <summary>
        /// 根据联系人编号，获取联系人信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Model.Contact GetModel(int Id);
    }
}
