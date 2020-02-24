namespace HallOfFameClient.Views
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectPage : ContentPage
    {
        public ConnectPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        /// <summary>
        /// Адрес апи.
        /// </summary>
        public string Url { get; set; }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(Url));
        }
    }
}