namespace HallOfFameClient.Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using HallOfFameClient.Models;
    using HallOfFameClient.Utils;

    using Newtonsoft.Json;

    public class PersonsService
    {
        private const string URL = "http://192.168.0.105:52480/api/persons";

        /// <summary>
        /// Метод получения сотрудников.
        /// </summary>
        public async Task<List<Person>> GetPersonsAsync(string url)
        {
            var client = GetClient();
            //var url = ConnectionUtils.GetAddressConnection();

            var result = await client.GetStringAsync($"http://{url}/api/persons");

            return JsonConvert.DeserializeObject<List<Person>>(result);
        }

        /// <summary>
        /// Получение клиента.
        /// </summary>
        /// <returns>Http-клиент.</returns>
        private HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}