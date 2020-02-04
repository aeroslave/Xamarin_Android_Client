namespace HallOfFameClient.Views
{
    using HallOfFameClient.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        //public PersonPage()
        //{
        //    InitializeComponent();
        //}

        public PersonPage(PersonPageVM personPageVM)
        {
            InitializeComponent();

            Title = "Перечень навыков";
            BindingContext = personPageVM;
        }
    }
}