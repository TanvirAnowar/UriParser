using System;
using System.Linq;
using VpUriParser.UriParser;

namespace VpUriParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // string queryString = @"http://userx@version1.api.memegenerator.net:4000/Comment_Create?entityName=Instance&entityID=72628355&parentCommentID=&text=first%20post%20best%20post&apiKey=demo";
            string queryString = @"http://www.google.com/";
            // UriParser uriParser = new UriParser(queryString);

            // uriParser.ParserSelector();

            //  QueryUtility.HttpAuthorityUtil("sdfds.com:223");

            //var result = QueryUtility.HttpQueryStringUtil(queryString);            

            UriParserEnginer uriParser = new UriParserEnginer(queryString);

            uriParser.ParserSelector();
             




        }
    }
}
