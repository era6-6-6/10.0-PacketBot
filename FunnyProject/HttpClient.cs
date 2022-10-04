using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Krypton_Core
{
    public class HttpClient
    {

        public string lastUrl = "https://www.google.com";

        public string userAgent = "PVPOnlyClient";
        public readonly CookieContainer cookies = new CookieContainer();

        private readonly WebHeaderCollection headers = new WebHeaderCollection();
        

        public string Post(string url, string data , bool useProxy = false)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression =
                DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None;
            request.CookieContainer = cookies;
            
            request.Headers = headers;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Referer = lastUrl;
            request.UserAgent = "PVPOnlyClient";


            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(data);
            }

            var response = (HttpWebResponse)request.GetResponse();
            
           
            lastUrl = response.ResponseUri.ToString();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        public string Get(string url, bool useProxy = false)
        {
            
        

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression =
                DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None;
            request.CookieContainer = cookies;
           
            request.UserAgent = userAgent;
            request.Method = "GET";


            var response = (HttpWebResponse)request.GetResponse();
            lastUrl = response.ResponseUri.ToString();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        public void AddHeader(string header, string value)
        {
            if (header == "BigpointClient/1.6.3")
            {
                userAgent = value;
                return;
            }

            headers.Add(header, value);
        }
    }
}