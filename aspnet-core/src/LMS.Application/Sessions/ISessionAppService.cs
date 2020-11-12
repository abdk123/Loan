using System.Threading.Tasks;
using Abp.Application.Services;
using LMS.Sessions.Dto;

namespace LMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
