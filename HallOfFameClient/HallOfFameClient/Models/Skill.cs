namespace HallOfFameClient.Models
{
    /// <summary>
    /// Модель навыка.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Уровень.
        /// </summary>
        public byte Level { get; set; }
    }
}