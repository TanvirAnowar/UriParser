# Welcome to VP URI Parser!
This URI Parser library parser segmented information based on URI Schema type.

# Using the library
Right now the current library can parse HTTP, HTTPS, and MailTo Schema. This can be extended to the LDAP, FTP and other URI

Initializing the object :
**string** uriString = @"http://www.example.com";
**UriParserEnginer** uriParserEnginer = **new UriParserEnginer(uriString)**;  

// **Executing the parser** 
**var** uriData = **uriParser.ParserSelector()**;

// **Accessing the URI data Model**
uriData.Schema ;// URI Schema
uriData.Authority ;// URI Authority
uriData.UserInfo ;//  Username inside the URI
uriData.Host ;// URI Host
uriData.Port ;// URI Port
uriData.Path ;// URI Path
uriData.Query ; // URI Query string ( showing only string)
uriData.QueryStringInfo ;// Query string information saved in Dicttionary (Key value pair)
uriData.Fragment ;// URI fragment

# Improvement opportunity

1. Implementing JSON Deserializer for making the Object portable.
2. Strategy Pattern can be implemented for a different type of object parsing.
3. DTO can be implemented to transfer data to Model
4. DI can be implemented to make the classes more loosely coupled.