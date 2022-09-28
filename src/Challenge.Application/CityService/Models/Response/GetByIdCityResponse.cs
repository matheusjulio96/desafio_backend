using Challenge.Application.Common;
using Challenge.Application.CityService.Models.Dtos;

namespace Challenge.Application.CityService.Models.Response
{
    public class GetByIdCityResponse : BaseResponse
    {
        public CityDto City { get; set; }
    }
}
