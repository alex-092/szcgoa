# 新手设计OA 系统设计
## 控制器设计

### 认证模块[允许匿名]Account Controller
	>页面
		- 登录页面 Login
		- 注册成功 RegSuccess  
		- 未授权访问跳转 UnAuth

	> API 
		- 登录  Login POST
		- 注册  Register POST
		- 重置密码 Forgot POST
		- 注销登录 Logout Get


### 系统管理控制器 Manage Controller
	- 菜单管理 SysMenu
	> API
		- 菜单列表 MenuList Get
		- 菜单项 MenuItem [Get,Post,Put,Delete]

	- 用户管理 SysUser
	>API
		- 用户列表 UserList Get
		- 用户项目 UserItem GPPD
		- 用户角色 UserRoles GPPD
		
	- 角色管理 SysRole
	>API
		- 角色列表 RoleList Get
		- 角色项目 RoleItem GPPD
		- 角色权限 RoleAccess GP

	- 权限组管理 AuthrGroup
	- 角色组绑定 RoleGroup

#### 个人中心 Home Controller
	
	- 个人主页 Index
	- 信息管理 Mailbox
	>API
		- 收件列表
		- 发件列表
		- 草稿列表
		- 删除列表
		- 查看消息
		- 发送消息
		- 回复消息


	- 日志查询 Syslog
	- 我的图片 MyImages


#### 弹出式操作提示 Popup Controller

	- 通用已完成提示  WorkDone Get
	- 账户验证        ApproveUser  Get


