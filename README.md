# NPM_DGS_TOOLS
针对松下DGS编程软件/n
1, 可以提取已经注册的机器许可并保存成文本文件。/n
2，重置admin账号的密码为初始密码（pass）。/n
3，待添加其他功能。/n
/n
实现原理/n
通过使用windows用户登录MSSQL服务器来实现数据读取和修改，如果禁止了windows用户在SQL的登录权限则本工具失效。/n
