using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using FoodRecipesWebAPI.Exceptions;

namespace TestsProject
{
    [TestClass]
    public class ApiTests
    {
        private HttpClient _httpClient;

        public ApiTests()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }
      
        [TestMethod]
        [DataRow("https://localhost:7070/api/Recipe/38")]
        [DataRow("https://localhost:7070/api/Recipe/350")]
        public async Task Get_WhenCalled_ReturnsOkResult(string url)
        {           
            // Act
            var response = await _httpClient.GetAsync(url);
            // Assert           
            Assert.AreEqual("OK",
                response.StatusCode.ToString());
        }

        [TestMethod]
        [DataRow("https://localhost:7070/api/Recipe/10")]
        [DataRow("https://localhost:7070/api/Recipe/20")]
        public async Task Get_WhenCalled_ReturnsNotFoundResult(string url)
        {
            // Act
            var response = await _httpClient.GetAsync(url);
            // Assert           
            Assert.AreEqual("NotFound",
                response.StatusCode.ToString());
        }
        [TestMethod]
        public async Task Sum_Returns16For10And6()
        {
            // Act
            var response = await _httpClient.GetAsync("https://localhost:7070/api/Recipe/38");
            var stringResult = await response.Content.ReadAsStringAsync();
            // Assert                      
                response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.AreEqual("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}