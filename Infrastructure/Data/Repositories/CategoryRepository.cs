using System.Collections.Generic;
using MovieApp.Application.Interfaces;
using System.Linq;
using System.Net;
using MovieApp.Application.Entities;
using MovieApp.Infrastructure.Data;
using MovieApp.Application.DTO;

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

        public List<CategoryDto> GetCategories()
        {
            return db.Categories.Select(g => new CategoryDto
            {
                Id = g.Id,
                Name = g.Name,
                Link = g.Link
            })
            .OrderBy(g => g.Name).ToList();
        }
    }
}