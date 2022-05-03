using System;
using System.Linq;
using MovieApp.Core.DTO;
using MovieApp.Core.DTO.MovieAggregate.Filters;
using MovieApp.Core.Interfaces;
using MovieApp.Infrastructure.Data;

namespace MovieApp.Infrastructure.Services
{
    public class MovieFiltersService : IMovieFiltersService
    {
        private readonly ApplicationContext _context;
        private readonly ICategoryRepository _categoryRepository;
            
        public MovieFiltersService(ApplicationContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }
        
        public FilterOptionsDto GetFilters()
        {
            var restrictions = _context.Restrictions.Select(r => new RestrictionDto
            {
                Id = r.Id,
                Name = r.Name,
                Link = r.Link
            }).OrderBy(r => Convert.ToInt32(r.Link)).ToList();
            
            return new FilterOptionsDto
            {
                Categories = _categoryRepository.GetCategories(),
                Qualities = _context.Qualities.Select(q => new QualityDto
                {
                    Id = q.Id,
                    Name = q.Name
                }).OrderBy(q => q.Id).ToList(),
                Restrictions = restrictions,
                Countries = _context.Countries.Select(c => new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Link = c.Link
                }).OrderBy(c => c.Name).ToList(),
                YearMax = _context.Movies.Max(m =>  m.Release).Year,
                YearMin = _context.Movies.Min(m =>  m.Release).Year,
                RestrictionMax = restrictions.Last(),
                RestrictionMin = restrictions.First()
            };
        }
    }
}