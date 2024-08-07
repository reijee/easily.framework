# 配置Serilog日志记录器

Serilog是一个开源的日志记录库，可以记录应用程序的日志信息，并输出到控制台、文件、数据库等。
Serilog的配置可以通过代码或者配置文件进行配置，这里以代码配置为例。

1. 添加Serilog依赖包
   
~~~ bat
Install-Package Serilog.AspNetCore
Install-Package Serilog.Sinks.Async
~~~

Serilog.AspNetCore：Serilog的AspNetCore扩展包，用于在ASP.NET Core应用程序中集成Serilog。里面包含了ASP.NET Core所需的Serilog包。当前也可以不引用Serilog.AspNetCore，跟据项目情况按照需要引用所需要的包。

Serilog.Sinks.Async：Serilog的异步日志记录器，用于异步记录日志，防止日志记录阻塞应用程序。

2. 在Program的Main方法中配置Serilog日志记录器

~~~ csharp
public static void Main(string[] args)
{
    #region 配置Serilog日志记录器
    Log.Logger = new LoggerConfiguration()
#if DEBUG
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
#else
    .MinimumLevel.Warning()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
#endif
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Async(c => c.File("Logs/logs.log", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true, fileSizeLimitBytes: 1024 * 1024 * 5))
#if DEBUG
    .WriteTo.Async(c => c.Console())
#endif
    .CreateLogger();
    #endregion

    try
    {
        Log.Information("WebHost Starting...");
        var builder = WebApplication.CreateBuilder(args);

        // 使用Serilog日志记录器
        builder.Host.UseSerilog();

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
    catch (Exception ex)
    {
        if (ex is HostAbortedException)
        {
            throw;
        }

        Log.Fatal(ex, "Host terminated unexpectedly!");
    }
    finally
    {
        Log.CloseAndFlush();
    }
}
~~~

在Program的Main方法中，首先创建一个Serilog日志记录器，并配置了日志记录器的最小级别、日志记录器的重写级别、日志记录器的附加信息、日志记录器的输出目标等。然后调用 “builder.Host.UseSerilog()”向ASP.NET Core主机添加Serilog日志记录器。