using rootear.mvvm.ViewModels;
using rootear.Services;

namespace rootear.mvvm.Views;

public partial class LoginPage : ContentPage
{
    private LoginViewModel viewModel;
    public LoginPage()
    {
        LoginService service = new LoginService();
        BindingContext = viewModel = new LoginViewModel(service);
        InitializeComponent();
    }
}