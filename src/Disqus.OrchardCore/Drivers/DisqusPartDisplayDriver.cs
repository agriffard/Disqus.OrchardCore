using System.Linq;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using Disqus.OrchardCore.Models;
using Disqus.OrchardCore.Settings;
using Disqus.OrchardCore.ViewModels;

namespace Disqus.OrchardCore.Drivers
{
    public class DisqusPartDisplayDriver : ContentPartDisplayDriver<DisqusPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public DisqusPartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(DisqusPart disqusPart)
        {
            return Combine(
                Initialize<DisqusPartViewModel>("DisqusPart", m => BuildViewModel(m, disqusPart))
                    .Location("Detail", "Content:20"),
                Initialize<DisqusPartViewModel>("DisqusPart_Summary", m => BuildViewModel(m, disqusPart))
                    .Location("Summary", "Meta:5")
            );
        }
        
        public override IDisplayResult Edit(DisqusPart DisqusPart)
        {
            return Initialize<DisqusPartViewModel>("DisqusPart_Edit", m => BuildViewModel(m, DisqusPart));
        }

        public override async Task<IDisplayResult> UpdateAsync(DisqusPart model, IUpdateModel updater)
        {
            var settings = GetDisqusPartSettings(model);

            await updater.TryUpdateModelAsync(model, Prefix, t => t.ShowComments);
            
            return Edit(model);
        }

        public DisqusPartSettings GetDisqusPartSettings(DisqusPart part)
        {
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(part.ContentItem.ContentType);
            var contentTypePartDefinition = contentTypeDefinition.Parts.FirstOrDefault(p => p.PartDefinition.Name == nameof(DisqusPart));
            var settings = contentTypePartDefinition.GetSettings<DisqusPartSettings>();

            return settings;
        }

        private Task BuildViewModel(DisqusPartViewModel model, DisqusPart part)
        {
            var settings = GetDisqusPartSettings(part);

            model.ContentItem = part.ContentItem;
            model.ShortName = settings.ShortName;
            model.ShowComments = part.ShowComments;
            model.DisqusPart = part;
            model.Settings = settings;

            return Task.CompletedTask;
        }
    }
}
