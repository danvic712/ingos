using Ingos.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Ingos.Application.Contracts.Permissions
{
    public class IngosPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(IngosPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(IngosPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<IngosResource>(name);
        }
    }
}