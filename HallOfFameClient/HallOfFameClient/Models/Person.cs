namespace HallOfFameClient.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

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
        public ObservableCollection<Skill> Skills { get; set; }
    }
}