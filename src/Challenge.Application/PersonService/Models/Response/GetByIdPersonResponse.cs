using Challenge.Application.Common;
using Challenge.Application.PersonService.Models.Dtos;

namespace Challenge.Application.PersonService.Models.Response
{
    public class GetByIdPersonResponse : BaseResponse
    {
        public PersonDto Person { get; set; }
    }
}
