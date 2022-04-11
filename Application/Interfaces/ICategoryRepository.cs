using System;
using System.Collections.Generic;
using MovieApp.Application.DTO;
using MovieApp.Application.Entities;
using MovieApp.Application.DTO.CategoryAggregate;

namespace MovieApp.Application.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetCategory(int id);

        public Category GetCategory(string name);
        public List<CategoryDetailDto> GetCategories();

        CategoryDto UpdateCategory(CategoryDto category);

        // void AddCategory(Category movie);

        // void RemoveCategory(int Id);
    }
}