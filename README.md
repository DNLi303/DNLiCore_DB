--------------------------------------DNLiCore框架-----------------------------------------    
愿景:打造一款即装即用的快速开发框架，更少的耦合更多的功能更高效的开发效率    
--------------------------------------介绍说明---------------------------------------------    
DNLiCore_DB 是属于DNLiCore框架下的一个数据库工具类,目标支持数据库类型包括 MySql,SqlServer,SqlLite    
其中包括3种执行框架  
1.Ado.net:SqlHelper    
2.轻量级ORM:Petapoco    
3.标准EF框架:EF Core         

--------------------------------------使用说明---------------------------------------------    
1.通过nuget安装 DNLiCore_DB    
2.在appsettings.json配置所需要的数据库的配置例如    
  {    
  "ConnectionStrings": {    
                         "SqlServerConnection": "Server=xxxx;Database=xxx;User ID=xxx;Password=xxxx;",  //SqlServer配置    
                         "MySqlConnection": "Database='xxxx';Data Source=xxxx;User ID=xxxx;Password=xxxxx;CharSet=utf8;SslMode=None",  //MySql配置    
                         "SqlLiteConnection": "Data Source=xxxx.db"   //SqlLite配置    						 
                       }    
  }    
    
----------------------------------针对MySql的三种使用方法-------------------------------------     
1.使用Ado.Net  
  1.1 在Startup.cs 进行服务注入  
      services.AddSingleton(typeof(DNLiCore_DB.IMySqlHelper),new DNLiCore_DB.MySqlHelper(Configuration.GetConnectionString("MySqlConnection")));     
  1.2 在需要引用的地方进行构造注入引用，或者安装DNLiCore_DI框架可以在任意地方调用，例如:    
       DNLiCore_DI.ServiceContext.GetService<IMySqlHelper>().ExecuteSql(); //执行sql    
2.使用ORM:Petapoco  
  2.1 在Startup.cs 进行服务注入    
      services.AddSingleton(typeof(DNLiCore_DB.IPetaPocoHelper), new DNLiCore_DB.PetaPocoHelper(Configuration.GetConnectionString("MySqlConnection"), 0));  //0代表 mysql    
  2.2 在需要引用的地方进行构造注入引用，或者安装DNLiCore_DI框架可以在任意地方调用，例如:      
       DNLiCore_DI.ServiceContext.GetService<IPetaPocoHelper>().FirstOrDefault(); //查询实体    
3.使用EF Core    
  3.1 执行scaffold语句生成DBContext上下文和数据库实体	     
      Scaffold-DbContext -Force  "Server=xxxxx;User Id=xxxx;Password=xxxxx;Database=xxxxx" -Provider "Pomelo.EntityFrameworkCore.MySql"     
	  注意:表必须要有主键    
  3.2 在Startup.cs 进行服务注入    
      services.AddDbContext<xg_dbContext>(); //xg_dbContext是上一个步骤生成的上下文  
  3.3 在需要引用的地方进行构造注入引用，或者安装DNLiCore_DI框架可以在任意地方调用，例如:       
      DNLiCore_DI.ServiceContext.GetService<Model.monitoringplatformContext>().add();//增加  
	  引入System.Linq可以扩展更多的EF使用方式  
	      
	      
	      
	    
----------------------------------针对SqlServer的三种使用方法-------------------------------------    
1.使用Ado.Net  
  1.1 在Startup.cs 进行服务注入  
      services.AddSingleton(typeof(DNLiCore_DB.ISqlServerHelper),new DNLiCore_DB.SqlServerHelper(Configuration.GetConnectionString("SqlServerConnection")));   
  1.2 在需要引用的地方进行构造注入引用，或者安装DNLiCore_DI框架可以在任意地方调用，例如:  
       DNLiCore_DI.ServiceContext.GetService<ISqlServerHelper>().ExecuteSql(); //执行sql  
2.使用ORM:Petapoco  
  2.1 在Startup.cs 进行服务注入  
      services.AddSingleton(typeof(DNLiCore_DB.IPetaPocoHelper), new DNLiCore_DB.PetaPocoHelper(Configuration.GetConnectionString("SqlServerConnection"), 1));   //1代表 sqlserver    
  2.2 在需要引用的地方进行构造注入引用，或者安装DNLiCore_DI框架可以在任意地方调用，例如:    
       DNLiCore_DI.ServiceContext.GetService<IPetaPocoHelper>().FirstOrDefault(); //查询实体  
3.使用EF Core  
  3.1 执行scaffold语句生成DBContext上下文和数据库实体	   
      Scaffold-DbContext -Force "Server=xxxx;Database=xxxx;Trusted_Connection=True;Integrated Security=false;uid=xxxx; pwd=xxxx;" Microsoft.EntityFrameworkCore.SqlServer   
	  注意:表必须要有主键   
  3.2 在Startup.cs 进行服务注入   
      services.AddDbContext<xg_dbContext>(); //xg_dbContext是上一个步骤生成的上下文  
  3.3 在需要引用的地方进行构造注入引用，或者安装DNLiCore_DI框架可以在任意地方调用，例如:       
      DNLiCore_DI.ServiceContext.GetService<Model.monitoringplatformContext>().add();//增加   
	  引入System.Linq可以扩展更多的EF使用方式   
	    
	    
	    
	    
----------------------------------针对SqlLite的两种使用方法-------------------------------------    
1.使用Ado.Net  
  1.1 在Startup.cs 进行服务注入  
      services.AddSingleton(typeof(DNLiCore_DB.ISqlLiteHelper),new DNLiCore_DB.SqlLiteHelper(Configuration.GetConnectionString("SqlLiteConnection")));   
  1.2 在需要引用的地方进行构造注入引用，或者安装DNLiCore_DI框架可以在任意地方调用，例如:  
       DNLiCore_DI.ServiceContext.GetService<ISqlLiteHelper>().ExecuteSql(); //执行sql  
2.使用ORM:Petapoco  
  2.1 在Startup.cs 进行服务注入  
      services.AddSingleton(typeof(DNLiCore_DB.IPetaPocoHelper), new DNLiCore_DB.PetaPocoHelper(Configuration.GetConnectionString("SqlLiteConnection"), 2));   //1代表 sqllite    
  2.2 在需要引用的地方进行构造注入引用，或者安装DNLiCore_DI框架可以在任意地方调用，例如:    
       DNLiCore_DI.ServiceContext.GetService<IPetaPocoHelper>().FirstOrDefault(); //查询实体  