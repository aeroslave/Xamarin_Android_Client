namespace HallOfFameClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    using HallOfFameClient.Models;
    using HallOfFameClient.ViewModels;
    using HallOfFameClient.Views;

    using Newtonsoft.Json;

    using Xamarin.Forms;

    public partial class MainPage: ContentPage
    {
        //private Person _selectedPerson;

        private readonly MainPageVM _mainPageVM;

        public MainPage()
        {

            //Persons = new ObservableCollection<Person>();
            //Task.Run(() => GetPersons());
            InitializeComponent();
            _mainPageVM = new MainPageVM{Navigation = Navigation};
            BindingContext = _mainPageVM;
        }

        protected override async void OnAppearing()
        {
            await _mainPageVM.GetPersonsAsync();
            base.OnAppearing();
        }

        /// <summary>
        /// Метод получения сотрудников.
        /// </summary>
        //public async void GetPersons()
        //{
        //    var client = new HttpClient();
            
        //    var response = await client.GetAsync("http://192.168.0.105:52480/api/persons");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseContent = await response.Content.ReadAsStringAsync();
        //        var persons = JsonConvert.DeserializeObject<List<Person>>(responseContent);
        //        foreach (var person in persons)
        //            Persons.Add(person);
        //    }
        //}

        //public ObservableCollection<Person> Persons { get; set; }

        //public Person SelectedPerson
        //{
        //    get => _selectedPerson;
        //    set
        //    {
        //        _selectedPerson = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private async void AddPersonButton_OnClicked(object sender, EventArgs e)
        //{
        //    var person = new Person
        //    {
        //        Name = "Введите имя",
        //        Skills = new List<Skill>
        //        {
        //            new Skill
        //            {
        //                Name = "Введите наименовение навыка",
        //                Level = 0
        //            }
        //        }
        //    };

        //    Persons.Add(person);
        //    await Navigation.PushAsync(new PersonPage(person));
        //}

        //private void DeleteButton_OnClicked(object sender, EventArgs e)
        //{
        //    if (SelectedPerson == null)
        //        return;

        //    Persons.Remove(SelectedPerson);
        //}

        private async void NameDoubleTapped(object sender, EventArgs e)
        {
            if (_mainPageVM.SelectedPerson == null)
                return;

            await Navigation.PushAsync(new PersonPage(_mainPageVM.SelectedPerson));
        }
    }
}
