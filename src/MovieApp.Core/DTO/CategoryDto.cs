using MovieApp.Core.Entities;

namespace MovieApp.Core.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public static CategoryDto FromCategory(Category category) 
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Link = category.Link
            };
        }
    }
}