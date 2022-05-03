using System.Collections.Generic;

namespace MovieApp.Core.DTO.MovieAggregate.Filters
{
    public class FilterOptionsDto
    {
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<QualityDto> Qualities { get; set; } = new List<QualityDto>();
        public List<RestrictionDto> Restrictions { get; set; } = new List<RestrictionDto>();
        public List<CountryDto> Countries { get; set; } = new List<CountryDto>();
        public int YearMax { get; set; }
        public int YearMin { get; set; }
        public RestrictionDto RestrictionMax { get; set; }
        public RestrictionDto RestrictionMin { get; set; }
    }
}