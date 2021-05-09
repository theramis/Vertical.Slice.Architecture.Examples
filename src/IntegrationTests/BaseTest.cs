using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Snapper;
using Xunit;

namespace IntegrationTests
{
    public abstract class BaseTest<T> : IClassFixture<WebApplicationFactory<T>>
        where T : class
    {
        private readonly WebApplicationFactory<T> _factory;

        public BaseTest(WebApplicationFactory<T> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Given()
        {
            var client = _factory.CreateClient();

            var response = await client.GetStringAsync("/todos");

            response.ShouldMatchInlineSnapshot("[]");
        }
    }
}
