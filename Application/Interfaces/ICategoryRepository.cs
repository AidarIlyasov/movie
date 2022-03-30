using System.Collections.Generic;
using MovieApp.Application.Entities;
using MovieApp.Application.DTO;

namespace MovieApp.Application.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetCategory(int id);

        public Category GetCategory(string name);
        public List<CategoryDto> GetCategories();
        // void AddCategory(Movie movie);
        // void UpdateCategory(Movie movie);
        // void RemoveCategory(int Id);
    }
}