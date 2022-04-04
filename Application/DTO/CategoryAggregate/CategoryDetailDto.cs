namespace MovieApp.Application.DTO.CategoryAggregate
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int MoviesCount { get; set; }
    }
}