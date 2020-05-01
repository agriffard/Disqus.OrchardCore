using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using Disqus.OrchardCore.Settings;
using Disqus.OrchardCore.Models;

namespace Disqus.OrchardCore.ViewModels
{
    public class DisqusPartViewModel
    {
        public string ShortName { get; set; }

        public bool HideComments { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public DisqusPart DisqusPart { get; set; }

        [BindNever]
        public DisqusPartSettings Settings { get; set; }
    }
}
