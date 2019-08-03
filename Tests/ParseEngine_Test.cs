using VpUriParse.Models;
using Xunit;

namespace VpUriParse.Tests
{
    public class ParseEngine_Test
    {
        [Fact]
        public void InitialTest()
        {
            UriModel uriModel = new UriModel();

            Assert.NotNull(uriModel);        
        }
        
    }
}