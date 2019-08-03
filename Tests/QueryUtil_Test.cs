using System;
using System.Linq;
using System.Collections.Generic;
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
        [InlineData("http://www.google.com/")]
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



        [Theory]
        [InlineData("contentUrl=https%3A%2F%2Fmemegenerator.net%2FJohnDoe%26reason%3Dpersonal%2520information%2520exposed%26email%3Demail%40domain.com%26apiKey%3Ddemo")]
        public void HttpQueryStringUtil_Test_QueryString(string queryString)
        {
            var result = QueryUtility.HttpQueryStringUtil(queryString);
           
            Assert.Equal(result.Keys.ElementAt(3), "apiKey");
            Assert.Equal(result[result.Keys.ElementAt(3)], "demo");
        }
    }
}