namespace HallOfFameClient.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Модель пользователя.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список навыков.
        /// </summary>
        public List<Skill> Skills { get; set; }
    }
}