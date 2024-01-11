using Cola.Core.Models.SystemBuilder;
using Cola.Core.Utils.Constants;
using Cola.CoreUtils.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cola.SystemBuilder;

public static class ColaCorsExtensions
{
    public static void AddColaCors(this IServiceCollection services,IConfiguration configuration)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        var colaCorsOptions = configuration.GetColaSection<ColaCorsOptions>(SystemConstant.CONSTANT_COLACORS_SECTION);
        services.AddCors(c =>
        {
            c.AddPolicy("LimitRequests", policy =>
            {
                // 支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                // 注意，http://127.0.0.1:1818 和 http://localhost:1818 是不一样的，尽量写两个
                policy
                    .WithOrigins(colaCorsOptions.Cors.Ip.Split(','))
                    .AllowAnyHeader() //Ensures that the policy allows any header.
                    .AllowAnyMethod();
            });

            // 允许任意跨域请求，也要配置中间件
            //c.AddPolicy("AllRequests",policy=> {
            //    policy.AllowAnyOrigin();
            //    policy.AllowAnyMethod();
            //    policy.AllowAnyHeader();
            //});
        });
        
    }
}