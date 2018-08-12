using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using SportsLiveScoreboard.Services.Communication;
using SportsLiveScoreboard.Web.Extensions;

namespace SportsLiveScoreboard.Web
{
    public class ServicesModule:IServicesModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, GmailEmailSender>();
        }
    }
}