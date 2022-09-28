using Challenge.Application.CityService.Models.Dtos;
using Challenge.Application.Common;

namespace Challenge.Application.CityService.Models.Response
{
    public class GetAllCityResponse : BaseResponse
    {
        public List<CityDto> Cities { get; set; }
    }
}
