using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Library;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace UnitTest
{
    public class BooksControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BooksControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Replace the database context with an in-memory database
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

                    if (descriptor != null)
                        services.Remove(descriptor);

                    services.AddDbContext<AppDbContext>(options =>
                        options.UseInMemoryDatabase("TestDb"));
                });
            });
        }

        [Fact]
        public async Task GetBooksSortedByPublisher_ReturnsOkAndBooks()
        {
            // Arrange
            var client = _factory.CreateClient();
            await SeedTestDataAsync(client);

            // Act
            var response = await client.GetAsync("/api/books/sorted-by-publisher");
            var responseContent = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<Book>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(books);
            Assert.Equal("HarperCollins", books[0].Publisher);
        }

        [Fact]
        public async Task BulkInsertBooks_ReturnsOkAndInsertsBooks()
        {
            // Arrange
            var client = _factory.CreateClient();
            var booksToInsert = new List<Book>
        {
            new Book
            {
                Publisher = "HarperCollins",
                Title = "1984",
                AuthorLastName = "Orwell",
                AuthorFirstName = "George",
                Price = 8.99M
            },
            new Book
            {
                Publisher = "Penguin Random House",
                Title = "The Great Gatsby",
                AuthorLastName = "Fitzgerald",
                AuthorFirstName = "F. Scott",
                Price = 10.99M
            }
        };
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(booksToInsert),
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await client.PostAsync("/api/books/bulk-insert", jsonContent);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private async Task SeedTestDataAsync(HttpClient client)
        {
            var booksToInsert = new List<Book>
        {
            new Book
            {
                Publisher = "Penguin Random House",
                Title = "The Great Gatsby",
                AuthorLastName = "Fitzgerald",
                AuthorFirstName = "F. Scott",
                Price = 10.99M
            },
            new Book
            {
                Publisher = "HarperCollins",
                Title = "1984",
                AuthorLastName = "Orwell",
                AuthorFirstName = "George",
                Price = 8.99M
            }
        };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(booksToInsert),
                Encoding.UTF8,
                "application/json");

            await client.PostAsync("/api/books/bulk-insert", jsonContent);
        }
    }

}
