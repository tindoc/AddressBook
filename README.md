# AddressBook
本项目是根据周宏斌、温一军主编的《C#数据库应用程序开发技术与案例教程》实现的程序

# Task 1

可以直接根据 [SqlServerSetting/readme.md](./SqlServerSetting/readme.md) 的提示配置 SQL Server 数据库环境

# Task 2

ToolStrip 工具栏上添加的是 button ，根据控件名称 tsbtnxxxx 得知

可以使用类内 static 成员来保存程序整个运行期间不变的变量，类 DBHelper 就是如此

# Task 5

ComboBox 的 DropDownStyle 属性设置为 DropDownList 之后只能在组合框中选取

# Task 7

需要 using System.IO 才可以使用 File 类

**这个备份和恢复只能在客户端和数据库在同一台主机上才可以实现，暂不支持远程备份**

# Task 11

Stored Procedure 存储过程优点：

- 预编译：存储过程预先编译好放在数据库内，减少编译语句所花的时间
- 缓存：编译好的会进入缓存，第二次执行的速度明显提高
- 减少网络传输：



# 优化

- 每次写数据库的连接很麻烦
- 写弹出消息框也较为麻烦
- 将是否选中 DataGridView 中行的判断封装
- FormContactAdd 和 FormContactDetail 相同函数 FillGroup 和 Check，提取



# 书籍勘误

- P46 第四行：*（1）定义FormContactList窗体的私有字段。* 应为 *（1）定义FormContact**Detail**窗体的私有字段。*

