namespace HallOfFameClient.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using HallOfFameClient.Models;
    using HallOfFameClient.Service;
    using HallOfFameClient.Views;

    using Xamarin.Forms;

    public class MainPageVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Сервис взаимодействия с API.
        /// </summary>
        private readonly PersonsService _personsService = new PersonsService();

        /// <summary>
        /// Флаг обновления.
        /// </summary>
        private bool _isRefreshing;

        /// <summary>
        /// Адрес апи.
        /// </summary>
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выбранный пользователь.
        /// </summary>
        private Person _selectedPerson;

        /// <summary>
        /// Адрес апи.
        /// </summary>
        private string _url;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainPageVM()
        {
            Persons = new ObservableCollection<Person>();
            GetPersonsCommand = new Command(GetPersons);
            ShowPersonCommand = new Command(ShowPersonPage);
            //GetPersons();
        }

        /// <summary>
        /// Команда получения списка пользователей.
        /// </summary>
        public ICommand GetPersonsCommand { get; protected set; }

        /// <summary>
        /// Команда перехода на страницу пользователя.
        /// </summary>
        public ICommand ShowPersonCommand { get; set; }

        /// <summary>
        /// Флаг обновления списка пользователей.
        /// </summary>
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Навигатор.
        /// </summary>
        public INavigation Navigation { get; set; }

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
                ShowPersonCommand.Execute(null);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Получение сотрудников.
        /// </summary>
        public void GetPersons()
        {
            Task.Run(GetPersonsAsync);
        }

        /// <summary>
        /// Показать страницу пользователя.
        /// </summary>
        public async void ShowPersonPage()
        {
            await Navigation.PushAsync(new PersonPage(new PersonPageVM(SelectedPerson)));
        }

        /// <summary>
        /// Метод получения сотрудников.
        /// </summary>
        public async Task GetPersonsAsync()
        {
            while (Persons.Any())
                Persons.RemoveAt(Persons.Count - 1);

            IsRefreshing = true;

            var persons = await _personsService.GetPersonsAsync(Url);

            foreach (var person in persons)
            {
                Persons.Add(person);
            }

            IsRefreshing = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}