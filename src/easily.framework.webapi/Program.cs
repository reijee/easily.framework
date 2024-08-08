
using easily.framework.core.Bootstrappers;
using Serilog;
using Serilog.Events;

namespace easily.framework.webapi
{
    public class Program
    {
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
                .WriteTo.Async(c => c.File(
                    "Logs/logs.log",
                    rollingInterval: RollingInterval.Day, // 设置日志输出到文件中，文件名按天滚动，文件夹名称为日期加小时
                    rollOnFileSizeLimit: true,// 设置为 true，表示启用日志文件大小限制，当日志文件达到设定的大小后，会自动滚动到新的文件中。
                    fileSizeLimitBytes: 10_000_000, //设置每个日志文件的最大大小，单位是字节。这里的值是 10MB，即 10_000_000 字节。
                    retainedFileCountLimit: 200,//设置保留的日志文件数量上限，这里是 200，即最多保留最新的 200 个日志文件。
                    retainedFileTimeLimit: TimeSpan.FromDays(7),//设置日志文件的最长保留时间，这里是 7 天。
                    shared: true, // 多进程共享文件
                                    // 设置日志输出模板，包括时间戳、日志级别、日志消息、日志来源和异常信息
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {NewLine}{Exception}"
                ))
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

                // 添加启动器
                builder.Host.AddBootstrapper();

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
    }
}
