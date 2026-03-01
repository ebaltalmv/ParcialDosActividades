using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataBindingExample.Models;
using DataBindingExample.Views;
using System.Collections.ObjectModel;

namespace DataBindingExample.ViewModels
{
    public partial class AirlinesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AirlineModel> _airlines;

        public AirlinesViewModel()
        {
            Airlines = AirlineModel.Airlines;
        }

        [RelayCommand]
        public async Task GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(AddAirlinePage));
        }

        [RelayCommand]
        public async Task GoToEditPage(AirlineModel airline)
        {
            await Shell.Current.GoToAsync(nameof(AddAirlinePage), new Dictionary<string, object> { ["Airline"] = airline });
        }
    }
}
