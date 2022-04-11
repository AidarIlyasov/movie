using System;
using System.Collections.Generic;
using MovieApp.Application.Interfaces;
using System.Linq;
using MovieApp.Application.DTO;
using MovieApp.Application.Entities;
using MovieApp.Infrastructure.Data;
using MovieApp.Application.DTO.CategoryAggregate;

namespace MovieApp.Infrastructure.Data.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Single(g => g.Id == id);
        }

        public Category GetCategory(string name)
        {
            return _context.Categories.Single(g=> g.Link == name);
        }

        public List<CategoryDetailDto> GetCategories()
        {
            return _context.Categories.Select(c => new CategoryDetailDto
            {
                Id = c.Id,
                Name = c.Name,
                Link = c.Link,
                MoviesCount = c.Movies.Count()
            })
            .OrderBy(c => c.Name).ToList();
        }

        public CategoryDto UpdateCategory(CategoryDto requestCategory)
        {
            var existCategory = _context.Categories.Single(c => c.Id == requestCategory.Id);

            if (existCategory == null)
            {
                throw new Exception($"Category with id {requestCategory.Id} not found");
            }

            existCategory.Name = requestCategory.Name;
            existCategory.Link = requestCategory.Link;

            _context.Update(existCategory);
            
            _context.SaveChanges();
            
            return new CategoryDto
            {
                Id = existCategory.Id,
                Name = existCategory.Name,
                Link = existCategory.Link
            };
        }
    }
}