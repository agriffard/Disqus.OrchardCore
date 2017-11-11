using OrchardCore.ContentManagement.Handlers;
using Disqus.OrchardCore.Models;

namespace Disqus.OrchardCore.Handlers
{
    public class DisqusPartHandler : ContentPartHandler<DisqusPart>
    {
        public override void Initializing(InitializingContentContext context, DisqusPart part)
        {
            // By default Comments are shown.
            part.ShowComments = true;
        }
    }
}