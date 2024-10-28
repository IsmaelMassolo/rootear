using CommunityToolkit.Mvvm.Input;

namespace rootear.mvvm.ViewModels
{
    public partial class AcercaViewModel : BaseViewModel
    {
        [RelayCommand]
        private async Task GoToMainPage()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}

