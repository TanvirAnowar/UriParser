using System;
using System.Collections.Generic;
using System.Web;

namespace VpUriParse.UriParser
{
    /* This class in used for manipulating string objects after getting parsed 
       the URI sagmented objects through Regular Expession from the UriParse class
     */
    public class QueryUtility
    {
        //Getting the Username and port from the Authority string
        public static Tuple<string, string> HttpAuthorityUtil(string authorityString)
        {
            // TODO: Should use Regular Expression instead of string operation.

            string cleanQuery = (authorityString.StartsWith("www.")) ? authorityString.Remove(0, 4) : authorityString;

            var queryData = cleanQuery.Split('@');

            string port, userName;

            if (queryData.Length > 1)
            {
                port = getPort(queryData[1]);
                userName = queryData[0];
            }
            else
            {
                port = getPort(queryData[0]);
                userName = "";
            }

            return Tuple.Create(userName, port);

        }

        // Parsing the port from authority string        

        private static string getPort(string queryString)
        {
            var data = queryString.Split(":");

            return (data.Length > 1) ? data[1] : "";
        }

        // Make a dictionary collection of key value pair of the Query segment of URI
        public static IDictionary<string, string> HttpQueryStringUtil(string queryString)
        {
            queryString = HttpUtility.UrlDecode(queryString);

            var content = queryString.Split("&");

            IDictionary<string, string> keyValue = new Dictionary<string, string>();
           
            foreach (var item in content)
            {
                var tempData = getKeyValuePairUtil(item);
                keyValue.Add(tempData.Item1, tempData.Item2);
            }  

            return keyValue;         

        }

        //Split the set of query string into Key Value pair 
        private static Tuple<string, string> getKeyValuePairUtil(string item)
        {
            var tempData = item.Split("=");
            string keyString = tempData[0].Trim();
            string valueString = tempData[1].Trim();

            return Tuple.Create(keyString,valueString);
        }

    }
    
}