using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PDSGBD
{
    /// <summary>
    /// Api client
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        /// Server prefix
        /// <para>Example : http://localhost/</para>
        /// </summary>
        public string ServerPrefix { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serverPrefix">Server prefix<para>Example : http://localhost/</para></param>
        public ApiClient(string serverPrefix = null)
        {
            if (string.IsNullOrEmpty(serverPrefix)) serverPrefix = "http://localhost/";
            if (!serverPrefix.EndsWith("/")) serverPrefix += "/";
            ServerPrefix = serverPrefix;
        }

        /// <summary>
        /// Executes get query
        /// </summary>
        /// <param name="result">Result of this query</param>
        /// <param name="url">Url of query</param>
        /// <param name="keyValuePairs">Key/value pairs</param>
        /// <returns>True if query is completed, false otherwise</returns>
        public bool Get(out string result, string url, params string[] keyValuePairs)
        {
            url = string.IsNullOrWhiteSpace(url) ? string.Empty : url.Trim();
            var queryData = new StringBuilder();
            for (int i = 0, n = keyValuePairs.Length; i < n; i += 2)
            {
                if (!string.IsNullOrWhiteSpace(keyValuePairs[i]))
                {
                    var name = keyValuePairs[i].Trim();
                    var value = string.IsNullOrEmpty(keyValuePairs[i + 1]) ? string.Empty : WebUtility.UrlEncode(keyValuePairs[i + 1]);
                    queryData.Append((queryData.Length == 0) ? "?" : "&");
                    queryData.Append($"{name}={value}");
                }
            }
            try
            {
                using (var client = new HttpClient())
                {
                    var task = client.GetStringAsync($"{ServerPrefix}{url}{queryData}");
                    task.Wait();
                    if (!task.IsCompleted) throw new Exception("Task not completed !");
                    result = task.Result;
                }
                return true;
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine($"\nApiClient.Get({ServerPrefix}{url}{queryData}) failed !\n{error.Message}\n");
                result = null;
                return false;
            }
        }
    }
}
