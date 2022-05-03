using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MovieApp.Core.DTO;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.MovieAggregate;
using MovieApp.backend.Controllers;
using MovieApp.Core.Interfaces;

namespace MovieApp.Dashboard.Tests
{
    public class MovieControllerTests
    {
        [Fact]
        public void GetMovieTest()
        {
            //Arrange
            const int movieId = 1;
            var serviceMock = new Mock<IMovieService>();
            var repositoryMock = new Mock<IMovieRepository>();
            serviceMock.Setup(repo => repo.GetMovieById(movieId)).Returns(GetTestMovie(movieId));
            var controller = new MovieController(repositoryMock.Object, serviceMock.Object);
            
            //Act
            var actionResult = controller.EditMovie(movieId);
            
            //Assert
            var result = actionResult as ObjectResult;
            Assert.NotNull(result);
            var returnMovie = result.Value as MovieDto;
            Assert.NotNull(returnMovie);
            Assert.Equal(movieId, returnMovie.Id);
            Assert.Equal(GetTestMovie(movieId).Title, returnMovie.Title);
        }

        private MovieDto GetTestMovie(int movieId)
        {
            return new MovieDto
            {
                Id = movieId,
                Title = "Test movie name",
                Slug =  "test-movie-name",
                Description = "just test",
                Duration = 164,
                Release = new DateTime(2017, 8, 16, 4, 2, 1).ToString("yyyy-MM-dd"),
                Restriction = new Restriction
                {
                    Id = 1,
                    Name = "21",
                },
                Countries = new List<Country>
                {
                  new Country()
                  {
                      Id = 1,
                      Name = "France",
                      Link = "france"
                  },
                  new Country()
                  {
                      Id = 2,
                      Name = "USA",
                      Link = "usa"
                  }
                },
                Categories = null,
                Raiting = 9.4d
            };
        }
    }
}

