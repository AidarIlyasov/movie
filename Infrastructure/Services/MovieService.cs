using MovieApp.Infrastructure.Data;
using MovieApp.Application.Entities;
using MovieApp.Application.DTO;
using MovieApp.Application.DTO.MovieAggregate;
using MovieApp.Application.Entities.MovieAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace MovieApp.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationContext _context;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        public MovieService(
            ApplicationContext context,
            IMovieRepository movieRepository,
            IMapper mapper,
            IFileManager fileManager
        )
        {
            _context = context;
            _movieRepository = movieRepository;
            _mapper = mapper;
            _fileManager = fileManager;
        }

        public MovieDto GetMovieBySlug(string slug)
        {
            var movie = _movieRepository
                .GetMovieBySlug(slug);
            
            return GetMovie(movie);
        }

        public MovieDto GetMovieById(int id)
        {
            var movie = _movieRepository
                .GetMovieById(id);

            return GetMovie(movie);
        }

        public async Task<Movie> UpdateMovie(UpdateMovieDto request)
        {
            var movie = _movieRepository
                .GetMovieById(request.Id);

            // if (movie == null || movie.Id != request.Id)
            // {
            //     throw new Exception("movie not found");
            // }

            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Slug = request.Slug;
            movie.Duration = request.Duration;
            movie.RestrictionId = request.Restriction.Id;
            movie.Release = DateTime.Parse(request.Release);

            movie.Categories = _context.Categories
                                .AsEnumerable()
                                .Where(cm => request.Categories.Any(c => c.Id == cm.Id))
                                .ToList();

            movie.Countries = _context.Countries
                                .AsEnumerable()
                                .Where(cm => request.Countries.Any(c => c.Id == cm.Id))
                                .ToList();
            movie.Qualities = _context.Qualities
                                .AsEnumerable()
                                .Where(qm => request.Qualities.Any(q => q.Id == qm.Id))
                                .ToList();

            // movie.Photos =
            //var photos = await CreatePhotos(request.Photos);

            _context.Entry(movie).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<List<CategoryDto>> RemoveCategory(int movieId, int catId)
        {
            var movie = _movieRepository.GetMovieById(movieId);
            var category = _context.Categories.Single(c => c.Id == catId);
            
            movie.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return movie.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Link = c.Link
            }).ToList();
        }

        private async Task<List<Photo>> CreatePhotos(List<PhotoDto> photos)
        {
            var createdPhotos = new List<Photo>();
                
            foreach (var photo in photos)
            {
                if (photo.Image != null)
                {
                    var createdImage = await _fileManager.SaveImage(photo.Image, photo.Id.ToString());
                    createdPhotos.Add(new Photo
                    {
                        Id = photo.Id,
                        Name = createdImage.Name,
                        IsPoster = photo.IsPoster
                    });
                }
            }

            return createdPhotos;
        }

        private static MovieDto GetMovie(Movie movie)
        {
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
                Release = movie.Release.ToString("yyyy-MM-dd"),
                Slug = movie.Slug,
                Raiting = Math.Round(1.0 * movie.Likes / (movie.Likes + movie.Dislikes) * 10, 1)
            };
        }
    }
}