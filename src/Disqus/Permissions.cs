using OrchardCore;
using OrchardCore.Security.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disqus.OrchardCore;

public sealed class Permissions : IPermissionProvider
{
    public static readonly Permission ManageDisqus = new("ManageDisqus", "Manage Disqus settings");

    private readonly IEnumerable<Permission> _allPermissions =
    [
        ManageDisqus,
    ];

    public Task<IEnumerable<Permission>> GetPermissionsAsync()
        => Task.FromResult(_allPermissions);

    public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
    [
        new PermissionStereotype
        {
            Name = OrchardCoreConstants.Roles.Administrator,
            Permissions = _allPermissions,
        },
    ];
}

