using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace LMS.Authorization
{
    public class LMSAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            //Nationalities
            context.CreatePermission(PermissionNames.Pages_Nationalities, L("Nationalities"));
            context.CreatePermission(PermissionNames.Pages_Nationalities_Create, L("CreateNewNationality"));
            context.CreatePermission(PermissionNames.Pages_Nationalities_Edit, L("EditNationality"));
            context.CreatePermission(PermissionNames.Pages_Nationalities_Delete, L("DeleteNationality"));
            //Countries
            context.CreatePermission(PermissionNames.Pages_Countries, L("Countries"));
            context.CreatePermission(PermissionNames.Pages_Countries_Create, L("CreateNewCountry"));
            context.CreatePermission(PermissionNames.Pages_Countries_Edit, L("EditCountry"));
            context.CreatePermission(PermissionNames.Pages_Countries_Delete, L("DeleteCountry"));
            //Case Status
            context.CreatePermission(PermissionNames.Pages_CaseStatus, L("CaseStatus"));
            context.CreatePermission(PermissionNames.Pages_CaseStatus_Create, L("CreateNewCaseStatus"));
            context.CreatePermission(PermissionNames.Pages_CaseStatus_Edit, L("EditCaseStatus"));
            context.CreatePermission(PermissionNames.Pages_CaseStatus_Delete, L("DeleteCaseStatus"));
            //Employees
            context.CreatePermission(PermissionNames.Pages_Employees, L("Employees"));
            context.CreatePermission(PermissionNames.Pages_Employees_Create, L("CreateNewEmployee"));
            context.CreatePermission(PermissionNames.Pages_Employees_Edit, L("EditEmployee"));
            context.CreatePermission(PermissionNames.Pages_Employees_Delete, L("DeleteEmployee"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LMSConsts.LocalizationSourceName);
        }
    }
}
