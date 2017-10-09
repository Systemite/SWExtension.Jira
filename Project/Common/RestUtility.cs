using System;
using System.IO;
using System.Net;
using System.Text;

namespace SWExtension.Jira.Common
{
    public static class RestUtility
    {
        public static string GetJson(string url, string username = null, string password = null)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                if (username != null)
                {
                    var base64Credentials = GetEncodedCredentials(username, password);
                    request.Headers.Add("Authorization", "Basic " + base64Credentials);
                }

                var response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        var errorText = reader.ReadToEnd();
                        // Might contain more information useful in a debugging situation, but not something we
                        // want to show the users.
                    }
                }
                throw;
            }
        }

        public static string PostJson(string url, string data, string username = null, string password = null)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                if (username != null)
                {
                    var base64Credentials = GetEncodedCredentials(username, password);
                    request.Headers.Add("Authorization", "Basic " + base64Credentials);
                }

                request.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        var errorText = reader.ReadToEnd();
                        // Might contain more information useful in a debugging situation, but not something we
                        // want to show the users.
                    }
                }
                throw;
            }
        }

        private static string GetEncodedCredentials(string username, string password)
        {
            var mergedCredentials = string.Format("{0}:{1}", username, password);
            var byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);

            return Convert.ToBase64String(byteCredentials);
        }
    }
}
