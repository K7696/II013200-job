using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScrumManager.Models
{
    public class ApiClient<T>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ApiClient()
        {

        }

        #endregion // Constructors

        #region public methods

        /// <summary>
        /// Get list of items from a web api
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<List<T>> GetList(string url)
        {
            List<T> items = new List<T>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(data);
                }
            }

            return items;
        }

        /// <summary>
        /// Get object from a web api
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T> GetObject(string url)
        {
            T item = default(T);

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    item = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
                }
            }

            return item;
        }


        #endregion // Public methods
    }
}
