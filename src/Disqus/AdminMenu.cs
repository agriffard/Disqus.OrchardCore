using Disqus.OrchardCore.Settings;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using System.Threading.Tasks;

namespace Disqus.OrchardCore;

public sealed class AdminMenu : AdminNavigationProvider
{
    private static readonly RouteValueDictionary _routeValues = new()
    {
        { "area", "OrchardCore.Settings" },
        { "groupId", DisqusPartSettings.GroupId },
    };

    internal readonly IStringLocalizer S;

    public AdminMenu(IStringLocalizer<AdminMenu> stringLocalizer)
    {
        S = stringLocalizer;
    }

    protected override ValueTask BuildAsync(NavigationBuilder builder)
    {        
        builder            
            .Add(S["Configuration"], configuration => configuration
                .Add(S["Settings"], S["Settings"].PrefixPosition(), settings => settings
                    .Add(S["Disqus"], S["Disqus"].PrefixPosition(), entry => entry
                        .AddClass("disqus")
                        .Id("disqus")
                        .Action("Index", "Admin", _routeValues)
                        .Permission(Permissions.ManageDisqus)
                        .LocalNav()
                    )
                )
            );

        return ValueTask.CompletedTask;
    }
}
