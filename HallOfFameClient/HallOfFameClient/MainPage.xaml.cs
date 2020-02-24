namespace HallOfFameClient
{
    using HallOfFameClient.ViewModels;

    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        private readonly MainPageVM _mainPageVM;

        public MainPage(string url)
        {
            InitializeComponent();
            _mainPageVM = new MainPageVM { Navigation = Navigation, Url = url};
            BindingContext = _mainPageVM;
        }

        protected override async void OnAppearing()
        {
            await _mainPageVM.GetPersonsAsync();
            base.OnAppearing();
        }
    }
}