using Disqus.OrchardCore.Settings;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

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
            .Add(S["Settings"], settings => settings
                .Add(S["Security"], S["Security"].PrefixPosition(), security => security
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
