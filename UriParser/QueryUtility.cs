using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using VpUriParser.Models;

namespace VpUriParse.UriParser
{
    /* This class in used for manipulating string objects after getting parsed 
       the URI sagmented objects through Regular Expession from the UriParse class
     */
    public class QueryUtility
    {
        //Getting the Username and port from the Authority string
        public static Tuple<string, string,string> HttpAuthorityUtil(string authorityString)
        {
            // TODO: Should use Regular Expression instead of string operation.

            string cleanQuery = (authorityString.StartsWith("www.")) ? authorityString.Remove(0, 4) : authorityString;

            var queryData = cleanQuery.Split('@');

            string host, port, userName;

            if (queryData.Length > 1)
            {
                port = getPort(queryData[1]);
                userName = queryData[0];
                host = getHost(queryData[1]);

            }
            else
            {
                port = getPort(queryData[0]);
                userName = "";
                host = getHost(queryData[0]);

            }


            return Tuple.Create(userName, port,host);

        }

        // Parsing the Host from authority string 

        private static string getHost(string queryString)
        {
            var data = queryString.Split(":");

            return (data.Length > 1) ? data[0] : queryString;
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
            string keyString = "";
            string valueString = "";
            var tempData = item.Split("=");
            if(tempData.Length > 0)
            {
                 keyString = tempData[0].Trim();
                 valueString = tempData[1].Trim();
            }

            return Tuple.Create(keyString,valueString);
        }

        // Make Model for URI segments

        public static UriModel MakeUriModelWithParsedData(Match data,Tuple<string,string,string> authorityInfo,IDictionary<string,string> queryStringInfo)
        {
            //TODO: should manage by DTO

            UriModel uriModel = new UriModel();

            uriModel.Scheme =  data.Groups["schema"].Value ?? "";
            uriModel.Authority = data.Groups["authority"].Value ?? "";
            uriModel.Path = data.Groups["path"].Value ?? "";
            uriModel.Query = data.Groups["query"].Value ?? "";
            uriModel.Fragment = data.Groups["fragment"].Value ?? "";

            uriModel.UserInfo = authorityInfo.Item1 ?? "";
            uriModel.Port = authorityInfo.Item2 ?? "";
            uriModel.Host = authorityInfo.Item3 ?? "";

            uriModel.QueryStringInfo = queryStringInfo;

            return uriModel;
            
        }

    }
    
}