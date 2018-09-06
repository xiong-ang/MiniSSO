# MiniSSO

> 一个小型的SSO系统，[参考](https://www.cnblogs.com/lyzg/p/6132801.html)   

## 系统目标  

+ 实现基于JWT的SSO
+ 界面美观
+ 对SSO的功能块进行抽象    
+ 测试驱动开发

## 功能划分

* AccessManager
  * 用户账号或session验证：不成功，不做任何操作；成功，设置cookie，设置重定向并带上token参数
  * JWT验证：提供JWT验证的RPC服务
  * LogOut：清除AM上的session信息  
* SomeClient
  * 依赖AM的JWT验证服务：验证成功，设置cookie，显示UI；验证不成功，重定向到AccessManager     
  * LogOut：调用AM的LogOut服务，并重定向到AM的LogIn界面         

## 问题总结    

+ JWT
+ 重定向Redirect      
+ UnitTest