namespace HallOfFameClient.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using HallOfFameClient.Models;
    using HallOfFameClient.Service;

    using Newtonsoft.Json;

    using Xamarin.Forms;

    public class MainPageVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Сервис взаимодействия с API.
        /// </summary>
        private PersonsService _personsService = new PersonsService();

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainPageVM()
        {
            Persons = new ObservableCollection<Person>();
            GetPersonsCommand = new Command(GetPersons);
            GetPersons();
        }

        public ICommand GetPersonsCommand { get; protected set; }

        /// <summary>
        /// Навигатор.
        /// </summary>
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Выбранный пользователь.
        /// </summary>
        private Person _selectedPerson;

        /// <summary>
        /// Список пользователей.
        /// </summary>
        public ObservableCollection<Person> Persons { get; set; }

        /// <summary>
        /// Выбранный пользователь.
        /// </summary>
        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Получение сотрудников.
        /// </summary>
        public void GetPersons()
        {
            Task.Run(GetPersonsAsync);
        }

        /// <summary>
        /// Метод получения сотрудников.
        /// </summary>
        public async Task GetPersonsAsync()
        {
            while (Persons.Any())
            {
                Persons.RemoveAt(Persons.Count - 1);
            }

            var persons = await _personsService.GetPersonsAsync();

            foreach (var person in persons)
                Persons.Add(person);
        }
    }
}