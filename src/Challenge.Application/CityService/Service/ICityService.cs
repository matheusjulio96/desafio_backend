using Challenge.Application.CityService.Models.Request;
using Challenge.Application.CityService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.CityService.Service
{
    public interface ICityService
    {
        Task<GetAllCityResponse> GetAllAsync();
        Task<GetByIdCityResponse> GetByIdAsync(int id);
        Task<CreateCityResponse> CreateAsync(CreateCityRequest request);
        Task<UpdateCityResponse> UpdateAsync(int id, UpdateCityRequest request);
        Task<DeleteCityResponse> DeleteAsync(int id);
    }
}
