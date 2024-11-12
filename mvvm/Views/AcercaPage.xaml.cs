using rootear.mvvm.ViewModels;

namespace rootear.mvvm.Views
{
    public partial class AcercaPage : ContentPage
    {
        public AcercaPage()
        {
            InitializeComponent();
            BindingContext = new AcercaViewModel();
        }
    }
}
