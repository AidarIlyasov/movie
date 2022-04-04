using System;
using System.Collections.Generic;
using MovieApp.Application.Entities;
using MovieApp.Application.DTO.CategoryAggregate;

namespace MovieApp.Application.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetCategory(int id);

        public Category GetCategory(string name);
        public List<CategoryDetailDto> GetCategories();
        // void AddCategory(Movie movie);
        // void UpdateCategory(Movie movie);
        // void RemoveCategory(int Id);
    }
}