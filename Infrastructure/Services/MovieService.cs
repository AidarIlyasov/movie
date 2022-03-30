using MovieApp.Infrastructure.Data;
using MovieApp.Application.Entities;
using MovieApp.Application.DTO;
using MovieApp.Application.Entities.MovieAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using System.Linq;

namespace MovieApp.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationContext _context;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(
            ApplicationContext context,
            IMovieRepository movieRepository,
            IMapper mapper
        )
        {
            _context = context;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public MovieDto GetMovie(int id)
        {
            Movie movie = _movieRepository.GetMovie(id);

            return new MovieDto {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Qualities = movie.Qualities.Select(q => new Quality {
                    Id = q.Id,
                    Name = q.Name
                }).ToList(),
                Categories = movie.Categories.Select(category => CategoryDto.FromCategory(category)).ToList(),
                Photos = movie.Photos.Select(photo => PhotoDto.FromPhoto(photo)).ToList(),
                // Comments = movie.Comments.Select(comment => _mapper.Map<CommentDto>(comment)),
                // Reviews = movie.Reviews.Select(review => _mapper.Map<ReviewDto>(review)),
                Countries = movie.Countries.Select(c => new Country {
                    Id = c.Id,
                    Name = c.Name,
                    Link = c.Link
                }).ToList(),
                Duration = movie.Duration,
                Restriction = new Restriction {
                    Id = movie.Restriction.Id,
                    Name = movie.Restriction.Name
                },
                Release = movie.Release_at.ToString("yyyy-MM-dd"),
                Slug = movie.Slug,
                Raiting = Math.Round(1.0 * movie.Likes / (movie.Likes + movie.Dislikes) * 10, 1)
            };
        }

        public Movie UpdateMovie(UpdateMovieDto request)
        {
            var movie = _context.Movies
                .Where(p => p.Id == request.Id)
                .Include(p => p.Categories)
                .FirstOrDefault();    

            movie.Categories = _context.Categories
                                .AsEnumerable()
                                .Where(cm => request.Categories.Any(c => c.Id == cm.Id))
                                .ToList();

            movie.Countries = _context.Countries
                                .AsEnumerable()
                                .Where(cm => request.Countries.Any(c => c.Id == cm.Id))
                                .ToList();

            // var countyMovie = _context.CountryMovies.Where(cm => cm.MovieId == request.Id);
           
            // countyMovie = _context.CountryMovies.Where(m => request.Countries.Any(c => c.Id == m.CountryId));

            // _context.Entry(countyMovie).State = EntityState.Modified;
            _context.Entry(movie).State = EntityState.Modified;

            _context.SaveChanges();

            // var existMovie = _movieRepository
            //     .GetMovieByIdTest(request.Id);


            
            // existMovie.Id = request.Id;
            // existMovie.Title = request.Title;
            // existMovie.Slug = request.Slug;
            // existMovie.Description = request.Description;

            // var countriesToRemove = _context.CountryMovies.Where(cm => cm.MovieId == request.Id).ToList();
            // _context.CountryMovies.RemoveRange(countriesToRemove);
            // _context.CountryMovies.AddRange(request.Countries.Select(cm => new CountryMovie {
            //     MovieId = request.Id,
            //     CountryId = cm.Id
            // }));


            // // 2. remove all ids already in database from requestStudent
            // request.Categories.RemoveAll(sc => existMovie.Categories.Exists(
            //     c => c.Id == sc.Id && existMovie.Id == request.Id
            //     ));

            // // 1. remove all except the "old"
            // existMovie.Categories.Clear();

            // // 3. add all nwe courses not yet seen in the database
            // existMovie.Categories.AddRange(request.Categories.Select(c => new Category {
            //     Id = c.Id,
            //     Name = c.Name,
            //     Link = c.Link
            // }));

            // _context.Update(existMovie);
            // _context.ChangeTracker.DetectChanges();
            // Console.WriteLine(_context.ChangeTracker.DebugView.LongView);

            return movie;
        }
        private List<Category> AddCategories(List<CategoryDto> categories, Movie movie)
        {
            List<Category> newCategories = new List<Category>();

            foreach(var c in categories)
            {
                movie.Categories.Add(new Category {
                    Id = c.Id,
                    Name = c.Name,
                    Link = c.Link
                });
            }

            return newCategories;
        }

        public void AddCountry(IEnumerable<CountryDto> countries, Movie movie)
        {
            // foreach(var country in countries)
            // {
            //     _context.CountryMovies.Add(new CountryMovie {
            //         MovieId = movie.Id,
            //         CountryId = country.Id
            //     });
            // }
        }
    }
}