using Disqus.OrchardCore.Drivers;
using Disqus.OrchardCore.Models;
using Disqus.OrchardCore.ViewModels;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Security.Permissions;

namespace Disqus.OrchardCore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<DisqusPartViewModel>();
            });
            services.AddContentPart<DisqusPart>()
                .UseDisplayDriver<DisqusPartDisplayDriver>();
            services.AddSiteDisplayDriver<DisqusPartSettingsDisplayDriver>()            
                .AddPermissionProvider<Permissions>()
                .AddNavigationProvider<AdminMenu>();
            services.AddDataMigration<Migrations>();
        }
    }
}
