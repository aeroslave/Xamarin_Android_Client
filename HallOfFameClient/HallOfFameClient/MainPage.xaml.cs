namespace HallOfFameClient
{
    using System;
    using System.Collections.Generic;

    using HallOfFameClient.Models;

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
                    Skills = new List<Skill> { js, karate }
                },
                new Person
                {
                    Name = "Robert Robertson",
                    Skills = new List<Skill> { skillLang, netCore }
                }
            };

            InitializeComponent();
            BindingContext = this;
        }

        public List<Person> Persons { get; set; }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Label.Text = "Button is clicked!";
        }
    }
}