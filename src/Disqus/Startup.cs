using Disqus.Drivers;
using Disqus.Handlers;
using Disqus.Models;
using Disqus.Settings;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace Disqus
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContentPartDisplayDriver, DisqusPartDisplayDriver>();
            services.AddSingleton<ContentPart, DisqusPart>();
            services.AddScoped<IContentTypePartDefinitionDisplayDriver, DisqusPartSettingsDisplayDriver>();
            services.AddScoped<IDataMigration, Migrations>();
            services.AddScoped<IContentPartHandler, DisqusPartHandler>();
        }
    }
}