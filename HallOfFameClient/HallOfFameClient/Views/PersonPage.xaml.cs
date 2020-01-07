namespace HallOfFameClient.Views
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using HallOfFameClient.Models;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        public ObservableCollection<Skill> Skills { get; set; }

        public PersonPage()
        {
            InitializeComponent();
        }

        public PersonPage(Person person)
        {
            InitializeComponent();

            Title = "Перечень навыков";
            NameLabel.Text = person.Name;
            Skills = person.Skills;
            BindingContext = person;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void AddSkillButton_OnClicked(object sender, EventArgs e)
        {
            Skills.Add(new Skill
            {
                Name = "Введите наименование навыка",
                Level = 0
            });
        }
    }
}