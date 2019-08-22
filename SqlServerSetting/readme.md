# 使用 sql 脚本文件恢复数据库环境

> script.sql 来源于 SSMS 中对特定数据库的执行 “任务 - 生成脚本” 生成

在 SSMS(Microsoft SQL Server Management Studio) 中新建一个查询，将文件 `script.sql` 拖到该窗口，执行即可

> SSMS 为免费软件，可到官网下载
>
> 本方式的缺点是 `script.sql` 中指定了 mdf 和 ldf 文件的位置，如果在你服务器上 SQLServer 的安装路径或者版本不一致的话可能导致该位置难以寻找