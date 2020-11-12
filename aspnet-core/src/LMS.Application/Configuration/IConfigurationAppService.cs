using System.Threading.Tasks;
using LMS.Configuration.Dto;

namespace LMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
