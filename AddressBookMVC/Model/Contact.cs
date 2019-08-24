using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class Contact
    {
        public Contact() { }

        #region Model
        private int _id;
        private string _name;
        private string _phone;
        private string _email;
        private string _qq;
        private string _workunit;
        private string _officephone;
        private string _homeaddress;
        private string _homephone;
        private string _memo;
        private int _groupid;

        /// <summary>
        /// 自动编号
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }
        
        /// <summary>
        /// 工作单位
        /// </summary>
        public string WorkUnit
        {
            get { return _workunit; }
            set { _workunit = value; }
        }
        
        /// <summary>
        /// 办公电话
        /// </summary>
        public string OfficePhone
        {
            get { return _officephone; }
            set { _officephone = value; }
        }
        
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string HomeAddress
        {
            get { return _homeaddress; }
            set { _homeaddress = value; }
        }
        
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string HomePhone
        {
            get { return _homephone; }
            set { _homephone = value; }
        }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        
        /// <summary>
        /// 分组编号
        /// </summary>
        public int GroupId
        {
            get { return _groupid; }
            set { _groupid = value; }
        }
        #endregion Model
    }
}
