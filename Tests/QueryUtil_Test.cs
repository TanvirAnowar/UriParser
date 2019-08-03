using VpUriParse.UriParser;
using VpUriParser.Models;
using Xunit;

namespace VpUriParse.Tests
{
    public class QueryUtil_Test
    {
        
        [Theory]
        [InlineData("max@google.com/")]
        
        public void HttpAuthorityUtil_Test_UserName(string queryString)
        {
            var result = QueryUtility.HttpAuthorityUtil(queryString);            

            Assert.Equal("max",result.Item1);
        }

        [Theory]
        [InlineData("www.google.com/")]
        public void HttpAuthorityUtil_Test_Empty_UserName(string queryString)
        {
            var result = QueryUtility.HttpAuthorityUtil(queryString);

            Assert.Equal("", result.Item1);
        }

        [Theory]
        [InlineData("x@google.com:4200")]
        public void HttpAuthorityUtil_Test_Port(string queryString)
        {
            var result = QueryUtility.HttpAuthorityUtil(queryString);

            Assert.Equal("4200", result.Item2);
        }
    }
}