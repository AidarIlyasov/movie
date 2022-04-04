using System;
using System.Collections.Generic;
using MovieApp.Application.Interfaces;
using System.Linq;
using MovieApp.Application.Entities;
using MovieApp.Infrastructure.Data;
using MovieApp.Application.DTO.CategoryAggregate;

namespace MovieApp.Infrastructure.Data.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationContext db;

        public CategoryRepository(ApplicationContext context)
        {
            db = context;
        }

        public Category GetCategory(int id)
        {
            return db.Categories.Single(g => g.Id == id);
        }

        public Category GetCategory(string name)
        {
            return db.Categories.Single(g=> g.Link == name);
        }

        public List<CategoryDetailDto> GetCategories()
        {
            return db.Categories.Select(c => new CategoryDetailDto
            {
                Id = c.Id,
                Name = c.Name,
                Link = c.Link,
                MoviesCount = c.Movies.Count()
            })
            .OrderBy(c => c.Name).ToList();
        }
    }
}