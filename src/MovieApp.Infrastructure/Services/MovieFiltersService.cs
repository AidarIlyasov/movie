using System.Linq;
using MovieApp.Core.DTO;
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
            return new FilterOptionsDto
            {
                Categories = _categoryRepository.GetCategories(),
                Qualities = _context.Qualities.Select(q => new QualityDto
                {
                    Id = q.Id,
                    Name = q.Name
                }).OrderBy(q => q.Id).ToList(),
                YearMax = _context.Movies.Max(m =>  m.Release).Year,
                YearMin = _context.Movies.Min(m =>  m.Release).Year
            };
        }
    }
}