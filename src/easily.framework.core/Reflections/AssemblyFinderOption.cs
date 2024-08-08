using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.Reflections
{
    public class AssemblyFinderOption
    {
        /// <summary>
        /// 默认选项
        /// </summary>
        public static AssemblyFinderOption DefaultOption => new AssemblyFinderOption() { 
            SkipPattern = "^System|^Mscorlib|^msvcr120|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted|^libuv|^api-ms|^clrcompression|^clretwrc|^clrjit|^coreclr|^dbgshim|^e_sqlite3|^hostfxr|^hostpolicy|^MessagePack|^mscordaccore|^mscordbi|^mscorrc|sni|sos|SOS.NETCore|^sos_amd64|^SQLitePCLRaw|^StackExchange|^Swashbuckle|WindowsBase|ucrtbase|^DotNetCore.CAP|^MongoDB|^Confluent.Kafka|^librdkafka|^EasyCaching|^RabbitMQ|^Consul|^Dapper|^EnyimMemcachedCore|^Pipelines|^DnsClient|^IdentityModel|^zlib|^NSwag|^Humanizer|^NJsonSchema|^Namotion|^ReSharper|^JetBrains|^NuGet|^ProxyGenerator|^testhost|^MediatR|^Polly|^AspNetCore|^Minio|^SixLabors|^Quartz|^Hangfire|^Handlebars|^Serilog|^WebApiClientCore|^BouncyCastle|^RSAExtensions|^MartinCostello|^Dapr.|^Bogus|^Azure.|^Grpc.|^HealthChecks|^Google|^CommunityToolkit|^Elasticsearch|^ICSharpCode|Enums.NET|^IdentityServer4|JWT|^MathNet|^MK.Hangfire|Mono.TextTemplating|Nest|^NPOI|^Oracle|Spire.Pdf|^FileSignatures"
        };

        /// <summary>
        /// 过滤的程序集，正则表达式
        /// </summary>
        public string SkipPattern { get; set; }

        /// <summary>
        /// 指定包含的程序集，正则表达式
        /// </summary>
        public string ContainPattern { get; set; }
    }
}
