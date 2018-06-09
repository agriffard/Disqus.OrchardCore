using OrchardCore.ContentManagement.Handlers;
using Disqus.OrchardCore.Models;
using System.Threading.Tasks;

namespace Disqus.OrchardCore.Handlers
{
    public class DisqusPartHandler : ContentPartHandler<DisqusPart>
    {
        public override Task InitializingAsync(InitializingContentContext context, DisqusPart part)
        {
            // By default Comments are shown.
            part.ShowComments = true;

            return Task.CompletedTask;
        }
    }
}