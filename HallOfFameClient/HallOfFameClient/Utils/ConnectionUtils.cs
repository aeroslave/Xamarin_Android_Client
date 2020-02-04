namespace HallOfFameClient.Utils
{
    using System;
    using System.IO;

    using HallOfFameClient.Models;

    using Newtonsoft.Json;

    /// <summary>
    /// Инструмент для работы с соединением.
    /// </summary>
    public static class ConnectionUtils
    {
        /// <summary>
        /// Получить адрес подключения.
        /// </summary>
        /// <returns>Адрес подключения.</returns>
        public static string GetAddressConnection()
        {
            var path = Environment.CurrentDirectory;
            var configTextFromFile = File.ReadAllText(path + "\\address_config.json");
            var connectionConfig = JsonConvert.DeserializeObject<ConnectionConfig>(configTextFromFile);

            return connectionConfig.Address;
        }
    }
}