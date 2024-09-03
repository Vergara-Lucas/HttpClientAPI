using FakeItEasy;
using FluentAssertions;
using HttpClientApi.Controllers;
using HttpClientApi.Models;
using HttpClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientApiTest.Services
{
    public class BirdTesting
    {

        private readonly IBirdsService _birdsService;
        private readonly HttpClient _httpClient;
        private readonly List<Bird> _ListBirds;
        public BirdTesting()
        {
            _birdsService = A.Fake<IBirdsService>();
            _httpClient = new HttpClient();//A.Fake<HttpClient>();
            _ListBirds = new List<Bird>() {
                new Bird{
                id =1, name ="Eagle", species="Haliaeetus leucocephalus", family ="Accipitridae"
                },
                new Bird{
                id =2, name ="Eagle 2", species="Haliaeetus leucocephalus", family ="Accipitridae"
                },
                new Bird{
                id =3, name ="Eagle 1", species="Haliaeetus leucocephalus", family ="Accipitridae"
                }
            };
        }
        [Fact]

        public void Get_OK()
        {
            //arrange
            A.CallTo(() => _birdsService.Get()).Returns(_ListBirds);
            List<Bird> expection = new List<Bird>();

            //Act
            var result = _birdsService.Get();

            //Assert.IsType<OkObjectResult>(result);
            result.Should().BeOfType<Task<List<Bird>>>();
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Task<List<Bird>>>();
            A.CallTo(() => _birdsService.Get()).MustHaveHappened();

        }

    }
}
