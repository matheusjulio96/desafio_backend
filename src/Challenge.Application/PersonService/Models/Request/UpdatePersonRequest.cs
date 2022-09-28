namespace Challenge.Application.PersonService.Models.Response
{
    public class UpdatePersonRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Document { get; set; }
        public int CityId { get; set; }
    }
}
