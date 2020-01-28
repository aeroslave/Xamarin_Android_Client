namespace HallOfFameClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Net.Http;
    using System.Threading.Tasks;

    using HallOfFameClient.Models;
    using HallOfFameClient.Views;

    using Newtonsoft.Json;

    using Xamarin.Forms;

    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private Person _selectedPerson;

        public MainPage()
        {
            var skillLang = new Skill
            {
                Name = "C#",
                Level = 5
            };

            var netCore = new Skill
            {
                Name = ".NetCore",
                Level = 6
            };

            var karate = new Skill
            {
                Name = "Karate",
                Level = 7
            };

            var js = new Skill
            {
                Name = "java script",
                Level = 3
            };

            Persons = new ObservableCollection<Person>
            {
                new Person
                {
                    Name = "John Smith",
                    Skills = new List<Skill> { js, karate }
                },
                new Person
                {
                    Name = "Robert Robertson",
                    Skills = new List<Skill> { skillLang, netCore }
                }
            };
            Task.Run(() => GetPersons());
            InitializeComponent();
            BindingContext = this;
        }

        public HttpClient HttpClient { get; set; }

        /// <summary>
        /// Метод получения сотрудников.
        /// </summary>
        public async void GetPersons()
        {
            var client = new HttpClient();
            
            var response = await client.GetAsync("http://192.168.0.105:52480/api/persons");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var persons = JsonConvert.DeserializeObject<Person>(responseContent);
            }
        }

        public ObservableCollection<Person> Persons { get; set; }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        private async void AddPersonButton_OnClicked(object sender, EventArgs e)
        {
            var person = new Person
            {
                Name = "Введите имя",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "Введите наименовение навыка",
                        Level = 0
                    }
                }
            };

            Persons.Add(person);
            await Navigation.PushAsync(new PersonPage(person));
        }

        private void DeleteButton_OnClicked(object sender, EventArgs e)
        {
            if (SelectedPerson == null)
                return;

            Persons.Remove(SelectedPerson);
        }

        private async void NameDoubleTapped(object sender, EventArgs e)
        {
            if (SelectedPerson == null)
                return;

            await Navigation.PushAsync(new PersonPage(SelectedPerson));
        }
    }
}