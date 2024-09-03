using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using HttpClientApi.Controllers;
using HttpClientApi.Models;
using HttpClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using RichardSzalay.MockHttp;
using System.Net;
using System.Net.Http;

namespace HttpClientApiTest.Services
{
    public class BeerTesting
    {
        private readonly BeersController _controller;
        private readonly IBeerService _beerService;
        private readonly List<Beer> _ListBeer;
        public BeerTesting()
        {

            _beerService = A.Fake<IBeerService>();
            _controller = new BeersController(_beerService);

            _ListBeer = new List<Beer>()
            {
                new Beer {
                    Id = 2,
                    price = "279.9",
                    name = "Heiniken",
                    rating = new rating{
                         average  ="nose",
                         reviews  = 6
                    },
                    image = "imagen.jpg"
                },
                new Beer {
                    Id = 3,
                    price = "279.9",
                    name = "Heiniken3",
                    rating = new rating{
                         average  ="nose",
                         reviews  = 6
                    },
                    image = "imagen.jpg"
                },
                new Beer {
                    Id = 1,
                    price = "279.9",
                    name = "Heiniken2",
                    rating = new rating{
                         average  ="nose",
                         reviews  = 6
                    },
                    image = "imagen.jpg"
                }
            };
        }
        [Fact]
        public async Task GetById_OKAsync()
        {
            //arrange
            A.CallTo(() => _beerService.GetById(2)).Returns(_ListBeer[0]);
            //act
            //assert
            var result = await _beerService.GetById(2);

            Assert.IsType<Beer>(result);
            result.Should().BeOfType<Beer>();
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Beer>();
            A.CallTo(() => _beerService.GetById(2)).MustHaveHappened();
        }
        [Fact]

        public async Task Get_OKAsync()
        {
            //arrange
            A.CallTo(() => _beerService.Get()).Returns(_ListBeer);


            //Act
            var result = await _beerService.Get();

            //Assert.IsType<OkObjectResult>(result);

            result.Should().BeOfType<List<Beer>>();
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<List<Beer>>();
            A.CallTo(() => _beerService.Get()).MustHaveHappened();

        }

    }
}