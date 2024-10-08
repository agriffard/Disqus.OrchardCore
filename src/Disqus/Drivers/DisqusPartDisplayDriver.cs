﻿using Disqus.OrchardCore.Models;
using Disqus.OrchardCore.Settings;
using Disqus.OrchardCore.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace Disqus.OrchardCore.Drivers
{
    public class DisqusPartDisplayDriver : ContentPartDisplayDriver<DisqusPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public DisqusPartDisplayDriver(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public override IDisplayResult Display(DisqusPart testPart, BuildPartDisplayContext context)
        {
            return Initialize<DisqusPartViewModel>(GetDisplayShapeType(context), m => BuildViewModel(m, testPart, context))
                .Location("Detail", "Content:20")
                .Location("Summary", "Content:20")
                ;
        }
        
        public override IDisplayResult Edit(DisqusPart part, BuildPartEditorContext context)
        {
            return Initialize<DisqusPartViewModel>(GetEditorShapeType(context), model =>
            {
                model.HideComments = part.HideComments;
                model.ContentItem = part.ContentItem;
                model.DisqusPart = part;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(DisqusPart model, UpdatePartEditorContext context)
        {
            await context.Updater.TryUpdateModelAsync(model, Prefix, t => t.HideComments);
            
            return Edit(model, context);
        }

        private Task BuildViewModel(DisqusPartViewModel model, DisqusPart part, BuildPartDisplayContext context)
        {
            var settings = context.TypePartDefinition.GetSettings<DisqusPartSettings>();

            model.ContentItem = part.ContentItem;
            model.ShortName = settings.ShortName;
            model.HideComments = part.HideComments;
            model.DisqusPart = part;
            model.Settings = settings;

            return Task.CompletedTask;
        }
    }
}
