using Challenge.Application.PersonService.Models.Request;
using Challenge.Application.PersonService.Models.Response;
using System.Threading.Tasks;

namespace Challenge.Application.PersonService.Service
{
    public interface IPersonService
    {
        Task<GetAllPersonResponse> GetAllAsync();
        Task<GetByIdPersonResponse> GetByIdAsync(int id);
        Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request);
        Task<UpdatePersonResponse> UpdateAsync(int id, UpdatePersonRequest request);
        Task<DeletePersonResponse> DeleteAsync(int id);
    }
}
