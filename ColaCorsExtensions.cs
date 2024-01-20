using Cola.Core.ColaConsole;
using Cola.Core.Models.SystemBuilder;
using Cola.CoreUtils.Constants;
using Cola.CoreUtils.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cola.SystemBuilder;

public static class ColaCorsExtensions
{
    public static void AddColaCors(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        var colaCorsOption = configuration.GetColaSection<ColaCorsOption>(SystemConstant.CONSTANT_COLACORS_SECTION);
        services.AddCors(c =>
        {
            foreach (var corsOption in colaCorsOption.Cors)
            {
                c.AddPolicy(corsOption.CorsName, policy =>
                {
                    if (!corsOption.AllowOriginsIp.StringIsNotNullOrEmpty())
                    {
                        policy = policy
                            .WithOrigins(corsOption.AllowOriginsIp.Split(','));
                    }
                    else
                    {
                        policy = policy.SetIsOriginAllowed(_ => true);
                    }

                    if (!corsOption.AllowHeaders.StringIsNotNullOrEmpty())
                    {
                        policy = policy.WithHeaders(corsOption.AllowHeaders.Split(','));
                    }
                    else
                    {
                        policy = policy.AllowAnyHeader();
                    }

                    policy.AllowAnyHeader();
                });
            }
        });
        ConsoleHelper.WriteInfo("AddColaCors 注入");
    }
}