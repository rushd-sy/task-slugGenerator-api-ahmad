using Microsoft.AspNetCore.Mvc.Testing;
using SlugApi.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace SlugApi.Test
{
    public class SlugControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public SlugControllerTests(WebApplicationFactory<Program> appFactory) => _client = appFactory.CreateClient();

        [Fact]
        public async Task POST_ValidInput_Returns200()
        {
            var request = new GenerateSlugRequest
            {
                Text = "Hello World",
                Separator = '_'
            };
            var response = await _client.PostAsJsonAsync("api/v1/slug", request);

            var body = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("hello_world", body);


        }
        [Fact]
        public async Task POST_EmptyInput_Returns400BadRequest()
        {
            var request = new GenerateSlugRequest
            {
                Text = ""
            };
            var response = await _client.PostAsJsonAsync("api/v1/slug", request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);          

        }
        [Fact]
        public async Task POST_InvalidInputSeparator_Returns400BadRequest()
        {
            var request = new GenerateSlugRequest
            {
                Text = "Hello World",
                Separator = '*'
            };
            var response = await _client.PostAsJsonAsync("api/v1/slug", request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
    }
}
