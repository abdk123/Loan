using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Crud.Interfaces
{
    public interface ICrudApplicationSevice<TReadDto> where TReadDto : class
    {
        Task<IList<TReadDto>> GetAllForGridAsync();
    }
}
