namespace Challenge.Application.PersonService.Models.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Document { get; set; }
        public int CityId { get; set; }

        public static explicit operator PersonDto(Domain.ChallengeAggregate.Person v)
        {
            return new PersonDto()
            {
                Id = v.Id,
                Name = v.Name,
                Age = v.Age,
                Document = v.Document,
                CityId = v.CityId
            };
        }
    }
}
