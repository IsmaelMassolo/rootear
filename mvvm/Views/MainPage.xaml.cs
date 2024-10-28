using rootear.mvvm.ViewModels;

namespace rootear.mvvm.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainViewModel viewModel = new MainViewModel();
            BindingContext = viewModel;
        }
    }
}
