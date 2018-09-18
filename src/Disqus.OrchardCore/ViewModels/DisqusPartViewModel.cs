using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using Disqus.OrchardCore.Models;
using Disqus.OrchardCore.Settings;

namespace Disqus.OrchardCore.ViewModels
{
    public class DisqusPartViewModel
    {
        public string ShortName { get; set; }

        public bool ShowComments { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public DisqusPart DisqusPart { get; set; }

        [BindNever]
        public DisqusPartSettings Settings { get; set; }
    }
}
