using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace HTTPProtocol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //01.Decode URL
            //DecodeUrl();

            //02. Validate URL
            //ValidateURL();

            //03. Request Parser
            RequestParser();
        }
        
        private static void DecodeUrl()
        {
            var url = Console.ReadLine();
            var decodeUrl = WebUtility.UrlDecode(url);
            Console.WriteLine(decodeUrl);
        }

        private static void ValidateURL()
        {
            var url = WebUtility.UrlDecode(Console.ReadLine());
            var uri = new Uri(url);

            if (uri.Port < 0 || (uri.Scheme == "http" && uri.Port == 443) || (uri.Scheme == "https" && uri.Port == 80))
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            Console.WriteLine($"Protocol: {uri.Scheme}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Path: {uri.AbsolutePath}");

            if (!string.IsNullOrEmpty(uri.Query))
            {
                var query = uri.Query.Substring(1);
                Console.WriteLine($"Query: {query}");
            }

            if (!string.IsNullOrEmpty(uri.Fragment))
            {
                var fragment = uri.Fragment.Substring(1);
                Console.WriteLine($"Fragment: {fragment}");
            }
        }

        private static void RequestParser()
        {
            var endPointsByHttpMethod = new Dictionary<string, HashSet<string>>();

            var input = Console.ReadLine().ToLower();

            while (input != "END")
            {
                var splitInput = input.Split("/", StringSplitOptions.RemoveEmptyEntries);

                var httpMethod = splitInput[1];
                var endPoint = splitInput[0];

                if (!endPointsByHttpMethod.ContainsKey(httpMethod))
                {
                    endPointsByHttpMethod.Add(httpMethod, new HashSet<string>());
                }

                endPointsByHttpMethod[httpMethod].Add(endPoint);

                input = Console.ReadLine();
            }

            var requestString = Console.ReadLine().ToLower();

            var requestStringSplit = requestString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var requestHttpMethod = requestStringSplit[0];
            var requestEndPoint = requestStringSplit[1].Trim('/');
            var requestHttpProtocol = requestStringSplit[2].ToUpper();

            if (endPointsByHttpMethod.ContainsKey(requestHttpMethod))
            {
                var endPoint = endPointsByHttpMethod[requestHttpMethod].FirstOrDefault(e => e == requestEndPoint);

                if (endPoint != null)
                {
                    var successHttpResponseString = $"{requestHttpProtocol} {(int)HttpStatusCode.OK} {HttpStatusCode.OK}" +
                        $"{Environment.NewLine}" +
                        $"Content - Length: {HttpStatusCode.OK.ToString().Length}" +
                        $"{Environment.NewLine}" +
                        $"Content - Type: text / plain" +
                        $"{Environment.NewLine}" +
                        $"{Environment.NewLine}" +
                        $"{HttpStatusCode.OK}";

                    Console.WriteLine(successHttpResponseString);
                    return;
                }
            }
                var errorHttpResponseString = $"{requestHttpProtocol} {(int)HttpStatusCode.NotFound} {HttpStatusCode.NotFound}" +
                        $"{Environment.NewLine}" +
                        $"Content - Length: {HttpStatusCode.NotFound.ToString().Length}" +
                        $"{Environment.NewLine}" +
                        $"Content - Type: text / plain" +
                        $"{Environment.NewLine}" +
                        $"{Environment.NewLine}" +
                        $"{HttpStatusCode.NotFound}";

            Console.WriteLine(errorHttpResponseString);
        }
    }
}
