namespace HallOfFameClient.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using HallOfFameClient.Annotations;
    using HallOfFameClient.Models;

    /// <summary>
    /// Вью-модель страницы пользователя.
    /// </summary>
    public class PersonPageVM : INotifyPropertyChanged
    {
        public PersonPageVM(Person person)
        {
            Skills = person.Skills;
            Name = person.Name;
        }
        /// <summary>
        /// Список навыков.
        /// </summary>
        public List<Skill> Skills { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}