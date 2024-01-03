using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using System.Threading.Tasks;

namespace Disqus.OrchardCore
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public async Task<int> CreateAsync()
        {
            await _contentDefinitionManager.AlterPartDefinitionAsync("DisqusPart", builder => builder
                .Attachable()
                .WithDescription("Provides a Disqus comment section for your content item."));

            return 1;
        }
    }
}