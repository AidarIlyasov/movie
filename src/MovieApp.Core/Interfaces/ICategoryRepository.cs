using System;
using System.Collections.Generic;
using MovieApp.Core.DTO;
using MovieApp.Core.Entities;
using MovieApp.Core.DTO.CategoryAggregate;

namespace MovieApp.Core.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetCategory(int id);

        public Category GetCategory(string name);
        public List<CategoryDetailDto> GetCategoriesDetails();
        public List<CategoryDto> GetCategories();

        CategoryDto UpdateCategory(CategoryDto category);

        CategoryDto AddCategory(CategoryDto category);

        void RemoveCategory(int Id);
    }
}