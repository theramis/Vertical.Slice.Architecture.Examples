using Example.Mediatr;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests
{
    public class ExampleMediatrTests : BaseTest<Startup>
    {
        public ExampleMediatrTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }
    }
}
