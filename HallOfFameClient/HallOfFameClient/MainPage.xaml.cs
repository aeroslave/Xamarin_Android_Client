namespace HallOfFameClient
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using HallOfFameClient.Models;
    using HallOfFameClient.Views;

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
                    Skills = new ObservableCollection<Skill> { js, karate }
                },
                new Person
                {
                    Name = "Robert Robertson",
                    Skills = new ObservableCollection<Skill> { skillLang, netCore }
                }
            };

            InitializeComponent();
            BindingContext = this;
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
                Skills = new ObservableCollection<Skill>
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