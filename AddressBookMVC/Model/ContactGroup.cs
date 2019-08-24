using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class ContactGroup
    {
        public ContactGroup() { }

        #region Model
        private int _id;
        private string _groupname;
        private string _memo;

        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName
        {
            get { return _groupname; }
            set { _groupname = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        #endregion Model
    }
}
