namespace HallOfFameClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using HallOfFameClient.Models;
    using HallOfFameClient.Views;

    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
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

            Persons = new List<Person>
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

        public List<Person> Persons { get; set; }

        //private async void PushToPersonPage(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new PersonPage());
        //}

        private async void PersonList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Person person))
                return;

            await Navigation.PushAsync(new PersonPage(person));
        }
    }
}