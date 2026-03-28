using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedResources.Models;
using System.Text.RegularExpressions;

namespace DataBindingExample.ViewModels
{
    public partial class AirlineViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _code;
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _country;
        [ObservableProperty]
        private string _phone;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsFormValid))]
        private bool _isCodeValid = true;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsFormValid))]
        private bool _isNameValid = true;

        public bool IsFormValid => IsCodeValid && IsNameValid;

        partial void OnCodeChanged(string value)
        {
            ValidateCode(value);
        }

        private void ValidateCode(string value)
        {
            // Letras y números, mínimo 2 caracteres
            IsCodeValid =
                 !string.IsNullOrWhiteSpace(value) &&
                 Regex.IsMatch(value, "^[A-Za-z0-9]{2,}$");
        }

        /// <summary>
        /// Invoked when the value of the name property changes, allowing for custom logic to be executed in response to
        /// the change.
        /// </summary>
        /// <param name="value">The new value assigned to the name property.</param>
        partial void OnNameChanged(string value)
        {
            ValidateName(value);
        }

        private void ValidateName(string value)
        {
            IsNameValid = !string.IsNullOrWhiteSpace(value);
        }

        [RelayCommand]
        public async Task SaveAirline()
        {
            var foundAirline = AirlineModel.Airlines.SingleOrDefault(a => a.Code == this.Code);
            if (foundAirline != null)
            {
                EditAirline(foundAirline);
                await Shell.Current.DisplayAlertAsync("Exito en la edición", "El registro se ha editado exitosamente", "OK");
                await Shell.Current.GoToAsync("..");
                return;
            }
            CreateAirline();
            await Shell.Current.GoToAsync("..");
        }

        private void CreateAirline()
        {
            AirlineModel airline = new()
            {
                Code = this.Code,
                Name = this.Name,
                Country = this.Country,
                Phone = this.Phone
            };

            AirlineModel.Airlines.Add(airline);
        }

        private void EditAirline(AirlineModel foundAirline)
        {
            foundAirline.Name = this.Name;
            foundAirline.Country = this.Country;
            foundAirline.Phone = this.Phone;
        }

        public void LoadAirlineForEdition(AirlineModel airline)
        {
            this.Code = airline.Code;
            this.Name = airline.Name;
            this.Country = airline.Country;
            this.Phone = airline.Phone;
        }
    }
}
