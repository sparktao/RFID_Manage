1. 创建数据库
在“包管理器控制台(PMC)”中，运行以下命令:

Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate
Update-Database

实现创建db数据库。


2. 运行应用
右键单击项目，并选择“编辑项目文件”
在 TargetFramework 属性下方，添加以下内容：

<StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory>

否则会导致引发异常： 无此类表格
