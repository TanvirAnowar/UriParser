using System.Text.RegularExpressions;
using VpUriParse.UriParser;
using VpUriParser.Models;

namespace VpUriParser.UriParser
{
    /* 
    This class is responsible for parsing data from URI string
    
    */
    public class UriParserEnginer
    {
        public string QueryString { get; set; }
        public string Schema { get; set; }

        private string[] getSegmentType()
        {
            //TODO: should come from setting file
            return new string[] { "http", "https", "mailto", "ldap", "news", "tel", "telnet", "urn" };
        }

        // Set the URI in property and find the schema type 
        public UriParserEnginer(string queryString)
        {
            QueryString = queryString;

            this.SchemaIdentifier();
        }

        // Identify the type of URI and distribute the task accordingly 
        public void SchemaIdentifier()
        {
            var segments = this.getSegmentType();

            foreach (var segment in segments)
            {
                //matching pattern URI Segment
                string regexPattern = $"^{segment}:";
                Schema = "";

                var data = this.regexExecutor(regexPattern, QueryString.ToLower());

                if (data.Success)
                {
                    // Exit from loop after getting matched segment
                    Schema = segment;
                    break;
                }
            }

        }        

        // Execute the regular expression and return the group data
        private Match regexExecutor(string regexPattern, string queryString)
        {
            Regex re = new Regex(regexPattern, RegexOptions.ExplicitCapture);
            return re.Match(queryString);
        }

        //Select differnt parsing logic based on Segment type
        public void ParserSelector()
        {
            var segmentType = this.getSegmentType();

            if (Schema.Equals(segmentType[0]) || Schema.Equals(segmentType[1]))
            {
                // For http and https Schema
                this.HttpParser();
            }else if(Schema.Equals(segmentType[2]))
            {
                this.MailParser();


            }

        }

        // Parser URI segments for HTTP/HTTPS
        public UriModel HttpParser()
        {
            //Help - https://www.cambiaresearch.com/articles/46/parsing-urls-with-regular-expressions-and-the-regex-object
            string regexPattern = @"^((?<schema>[^:/\?#]+):)?"
                                + @"(//(?<authority>[^/\?#]*))?"
                                + @"(?<path>[^\?#]*)"
                                + @"(\?(?<query>[^#]*))?"
                                + @"(#(?<fragment>.*))?";

            var data = this.regexExecutor(regexPattern, QueryString.ToLower());

            var authorityInfo = QueryUtility.HttpAuthorityUtil(data.Groups["authority"].Value);
            var queryStringKeyValues = QueryUtility.HttpQueryStringUtil(data.Groups["query"].Value);

            // Building accessable model with the parsed data
            var uriModel = QueryUtility.MakeUriModelWithParsedData(data,authorityInfo,queryStringKeyValues);

            return uriModel;
        }

        // Parser URI sagment for mailto:
        public UriModel MailParser()
        {
            string regexPattern = @"^((?<schema>[^:/\?#]+):)?"
                                + @"((?<path>[^/\?#]*))?";
            var data = this.regexExecutor(regexPattern,QueryString);

            // Building accessable model with the parsed data
            var uriModel = QueryUtility.MakeUriModelWithParsedData(data, null, null);

            return uriModel;
        }
    }
}