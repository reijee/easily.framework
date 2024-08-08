
using easily.framework.core.Bootstrappers;
using Serilog;
using Serilog.Events;

namespace easily.framework.webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region ����Serilog��־��¼��
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
                    rollingInterval: RollingInterval.Day, // ������־������ļ��У��ļ�������������ļ�������Ϊ���ڼ�Сʱ
                    rollOnFileSizeLimit: true,// ����Ϊ true����ʾ������־�ļ���С���ƣ�����־�ļ��ﵽ�趨�Ĵ�С�󣬻��Զ��������µ��ļ��С�
                    fileSizeLimitBytes: 10_000_000, //����ÿ����־�ļ�������С����λ���ֽڡ������ֵ�� 10MB���� 10_000_000 �ֽڡ�
                    retainedFileCountLimit: 200,//���ñ�������־�ļ��������ޣ������� 200������ౣ�����µ� 200 ����־�ļ���
                    retainedFileTimeLimit: TimeSpan.FromDays(7),//������־�ļ��������ʱ�䣬������ 7 �졣
                    shared: true, // ����̹����ļ�
                                    // ������־���ģ�壬����ʱ�������־������־��Ϣ����־��Դ���쳣��Ϣ
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

                // ʹ��Serilog��־��¼��
                builder.Host.UseSerilog();

                // ���������
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
