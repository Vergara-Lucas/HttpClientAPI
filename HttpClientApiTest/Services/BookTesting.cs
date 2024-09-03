using FakeItEasy;
using FluentAssertions;
using HttpClientApi.Controllers;
using HttpClientApi.Models;
using HttpClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientApiTest.Services
{
    public class BookTesting
    {
       
        private readonly IBooksService _bookService;
        private readonly List<Book> _ListBook;
        public BookTesting()
        {

            _bookService = A.Fake<IBooksService>();
             
            _ListBook = new List<Book>()
            {
                new Book {
                    id = 2,
                    title = "Señor de los anillos",
                    author = "unknow",
                    publication_year = "1954",
                    
                    description = "An epic fantasy saga about the quest to destroy the One Ring.",
                    cover_image = "https://fakeimg.pl/667x1000/cc6600"

                },
                new Book {
                    id = 2,
                    title = "Señor de los anillos2",
                    author = "unknow",
                    publication_year = "1954",

                    description = "An epic fantasy saga about the quest to destroy the One Ring.",
                    cover_image = "https://fakeimg.pl/667x1000/cc6600"

                },
                new Book {
                    id = 2,
                    title = "Señor de los anillos3",
                    author = "unknow",
                    publication_year = "1954",

                    description = "An epic fantasy saga about the quest to destroy the One Ring.",
                    cover_image = "https://fakeimg.pl/667x1000/cc6600"

                }
            };
        }
        [Fact]
        public async Task Get_OKAsync()
        {
            //arrange
            A.CallTo(() => _bookService.Get()).Returns(_ListBook);

            //Act
            var result = await _bookService.Get();

            //Assert.IsType<OkObjectResult>(result);
            result.Should().NotBeNull();
            result.Should().BeOfType<List<Book>>();
            result.Should().BeAssignableTo<List<Book>>();
            A.CallTo(() => _bookService.Get()).MustHaveHappened();

        }
    }
}


 