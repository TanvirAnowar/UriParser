using VpUriParse.Models;
using VpUriParse.UriParser;
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

        [Theory]
        [InlineData("http://www.google.com/")]
        [InlineData("https://www.google.com/")]
        [InlineData("mailto:x@google.com/")]
        [InlineData("news:google.com")]
        [InlineData("telnet:12.12.12.12")]
        [InlineData("urn:google:com")]
        public void UserParser_Test(string queryString)
        {
            UriParserEnginer uriParser = new UriParserEnginer(queryString);

            uriParser.SchemaIdentifier();

            Assert.NotNull(uriParser.Schema);
        }
        
    }
}