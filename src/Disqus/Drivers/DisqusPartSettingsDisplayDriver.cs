using Disqus.OrchardCore.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Settings;
using System.Threading.Tasks;

namespace Disqus.OrchardCore.Drivers
{
    public class DisqusPartSettingsDisplayDriver : SiteDisplayDriver<DisqusPartSettings>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DisqusPartSettingsDisplayDriver(
            IAuthorizationService authorizationService,
            IHttpContextAccessor httpContextAccessor)
        {
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<IDisplayResult> EditAsync(ISite site, DisqusPartSettings settings, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !await _authorizationService.AuthorizeAsync(user, Permissions.ManageDisqus))
            {
                return null;
            }

            return Initialize<DisqusPartSettingsViewModel>("DisqusPartSettings_Edit", model =>
            {
                model.ShortName = settings.ShortName;
                model.DisqusPartSettings = settings;

            }).Location("Content").OnGroup(SettingsGroupId);
        }

        protected override string SettingsGroupId
            => DisqusPartSettings.GroupId;

        public override async Task<IDisplayResult> UpdateAsync(ISite site, DisqusPartSettings settings, UpdateEditorContext context)
        {
            if (context.GroupId == SettingsGroupId)
            {
                var model = new DisqusPartSettingsViewModel();
                await context.Updater.TryUpdateModelAsync(model, Prefix);

                if (await context.Updater.TryUpdateModelAsync(model, Prefix, m => m.ShortName))
                {
                    settings.ShortName = model.ShortName;
                }
            }

            return await EditAsync(site, settings, context);
        }
    }
}
