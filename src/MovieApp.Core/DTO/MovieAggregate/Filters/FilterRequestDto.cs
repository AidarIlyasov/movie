namespace MovieApp.Core.DTO.MovieAggregate.Filters
{
    public class FilterRequestDto
    {
        public int Category { get; set; }
        public int Country { get; set; }
        public int Quality { get; set; }
        public int RestrictionMin { get; set; }
        public int RestrictionMax { get; set; }
        public int YearMin { get; set; }
        public int YearMax { get; set; }
    }
}