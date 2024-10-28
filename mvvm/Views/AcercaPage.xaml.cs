using rootear.mvvm.ViewModels;
using Microsoft.Maui.Controls;

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
