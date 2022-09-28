using Challenge.Application.CityService.Models.Dtos;
using Challenge.Application.CityService.Models.Request;
using Challenge.Application.CityService.Models.Response;
using Challenge.Application.Common;
using Challenge.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Challenge.Application.CityService.Service
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly ChallengeContext _db;

        public CityService(ILogger<CityService> logger, Infra.Data.ChallengeContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllCityResponse> GetAllAsync()
        {
            var entity = await _db.City.ToListAsync();
            return new GetAllCityResponse()
            {
                Cities = entity != null ? entity.Select(a => (CityDto)a).ToList() : new List<CityDto>()
            };
        }

        public async Task<GetByIdCityResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdCityResponse();

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.City = (CityDto)entity;

            return response;
        }

        public async Task<CreateCityResponse> CreateAsync(CreateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var newCity = Domain.ChallengeAggregate.City.Create(request.Name, request.Uf);

            _db.City.Add(newCity);

            await _db.SaveChangesAsync();

            return new CreateCityResponse() { Id = newCity.Id };
        }

        public async Task<UpdateCityResponse> UpdateAsync(int id, UpdateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Name, request.Uf);
                await _db.SaveChangesAsync();
            }

            return new UpdateCityResponse();
        }

        public async Task<DeleteCityResponse> DeleteAsync(int id)
        {

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCityResponse();
        }
    }
}
