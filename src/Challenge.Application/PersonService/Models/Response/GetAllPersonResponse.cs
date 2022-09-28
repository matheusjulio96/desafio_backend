using System.Collections.Generic;
using Challenge.Application.Common;
using Challenge.Application.PersonService.Models.Dtos;

namespace Challenge.Application.PersonService.Models.Response
{
    public class GetAllPersonResponse: BaseResponse
    {
        public List<PersonDto> Persons { get; set; }
    }
}
