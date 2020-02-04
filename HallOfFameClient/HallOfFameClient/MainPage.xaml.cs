namespace HallOfFameClient
{
    using System;

    using HallOfFameClient.ViewModels;
    using HallOfFameClient.Views;

    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        private readonly MainPageVM _mainPageVM;

        public MainPage()
        {
            InitializeComponent();
            _mainPageVM = new MainPageVM { Navigation = Navigation };
            BindingContext = _mainPageVM;
        }

        protected override async void OnAppearing()
        {
            await _mainPageVM.GetPersonsAsync();
            base.OnAppearing();
        }

        private async void NameDoubleTapped(object sender, EventArgs e)
        {
            if (_mainPageVM.SelectedPerson == null)
                return;

            var personPageVm = new PersonPageVM(_mainPageVM.SelectedPerson);
            await Navigation.PushAsync(new PersonPage(personPageVm));
        }
    }
}