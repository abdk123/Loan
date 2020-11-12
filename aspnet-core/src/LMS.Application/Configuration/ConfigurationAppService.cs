using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LMS.Configuration.Dto;

namespace LMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
