using System.Collections.Generic;

namespace MovieApp.Application.DTO
{
    public class FilterOptionsDto
    {
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<QualityDto> Qualities { get; set; } = new List<QualityDto>();
        public int YearMax { get; set; }
        public int YearMin { get; set; }
    }
}