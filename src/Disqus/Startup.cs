using Disqus.OrchardCore.Drivers;
using Disqus.OrchardCore.Models;
using Disqus.OrchardCore.Settings;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace Disqus.OrchardCore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<DisqusPart>()
                .UseDisplayDriver<DisqusPartDisplayDriver>();
            services.AddScoped<IContentTypePartDefinitionDisplayDriver, DisqusPartSettingsDisplayDriver>();
            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}