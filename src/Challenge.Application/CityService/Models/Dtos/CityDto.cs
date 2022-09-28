using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Application.CityService.Models.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }

        public static explicit operator CityDto(Domain.ChallengeAggregate.City v)
        {
            return new CityDto()
            {
                Id = v.Id,
                Name = v.Name,
                Uf = v.Uf
            };
        }
    }
}
