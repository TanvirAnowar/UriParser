using System.Text.RegularExpressions;

namespace VpUriParse.UriParser
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
            //todo: should come from setting file
            return new string[] { "http", "https", "ldap", "mailto", "news", "tel", "telnet", "urn" };
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
    }
}