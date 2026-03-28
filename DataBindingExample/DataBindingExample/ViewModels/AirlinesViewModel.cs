using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataBindingExample.Views;
using SharedResources.Models;
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

        [RelayCommand]
        public async Task DeleteAirline(AirlineModel airline)
        {
            string userAnswer = await Shell.Current.DisplayActionSheetAsync("¿Estas seguro de que quieres eliminar esta aerolinea?", "Cancelar", "Eliminar");
            if (userAnswer == "Cancelar") return;
            Airlines.Remove(airline);
        }
    }
}
