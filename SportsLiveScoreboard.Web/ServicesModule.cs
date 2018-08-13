using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using SportsLiveScoreboard.Services.Communication;
using SportsLiveScoreboard.Services.Data;
using SportsLiveScoreboard.Services.DateTimeProvider;
using SportsLiveScoreboard.Services.RandomCodes;
using SportsLiveScoreboard.Web.Extensions;

namespace SportsLiveScoreboard.Web
{
    public class ServicesModule:IServicesModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, GmailEmailSender>();
            services.AddScoped<ISportsData, SportsData>();

            services.AddTransient<IDateTimeProvider, SystemDateTimeProvider>();
            services.AddTransient<IRandomCodeProvider, DefaultCodeGenerator>();
        }
    }
}