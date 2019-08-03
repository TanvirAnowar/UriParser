using System.Collections.Generic;

namespace VpUriParser.Models
{
    // UriModel holds the fragmented data after parsing the URI
    public class UriModel
    {
       
        public string Scheme { get; set; }
        public string UserInfo { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Path { get; set; }
        public string Query { get; set; }
        public string Fragment { get; set; }
        public IDictionary<string, string> QueryStringInfo { get; set; }


        
    }
}