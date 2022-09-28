namespace Challenge.Application.PersonService.Models.Request
{
    public class CreatePersonRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Document { get; set; }
        public int CityId { get; set; }
    }
}
