using Challenge.Application.Common;
using Challenge.Application.PersonService.Models.Dtos;
using Challenge.Application.PersonService.Models.Request;
using Challenge.Application.PersonService.Models.Response;
using Challenge.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Challenge.Application.PersonService.Service
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly ChallengeContext _db;

        public PersonService(ILogger<PersonService> logger, Infra.Data.ChallengeContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllPersonResponse> GetAllAsync()
        {
            var entity = await _db.Person.ToListAsync();
            return new GetAllPersonResponse()
            {
                Persons = entity != null ? entity.Select(a => (PersonDto)a).ToList() : new List<PersonDto>()
            };
        }

        public async Task<GetByIdPersonResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdPersonResponse();

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Person = (PersonDto)entity;

            return response;
        }

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var city = await _db.City.FindAsync(keyValues: request.CityId);
            if (city is null) throw new ArgumentException("City doesn't exist!");

            var newPerson = Domain.ChallengeAggregate.Person.Create(request.Name, request.Age, request.Document, request.CityId);

            _db.Person.Add(newPerson);

            await _db.SaveChangesAsync();

            return new CreatePersonResponse() { Id = newPerson.Id };
        }

        public async Task<UpdatePersonResponse> UpdateAsync(int id, UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                var city = await _db.City.FindAsync(keyValues: request.CityId);
                if (city is null) throw new ArgumentException("City doesn't exist!");

                entity.Update(request.Name, request.Age, request.Document, request.CityId);
                await _db.SaveChangesAsync();
            }

            return new UpdatePersonResponse();
        }

        public async Task<DeletePersonResponse> DeleteAsync(int id)
        {

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePersonResponse();
        }
    }
}
