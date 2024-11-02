using rootear.Services;
using rootear.mvvm.ViewModels;

namespace rootear.mvvm.Views;

public partial class ViajeAgregarPage : ContentPage
{
        public ViajeAgregarPage()
        {
            InitializeComponent();
            BindingContext = new ViajeAgregarViewModel(new ViajeService(), new LugarService());
        }

}