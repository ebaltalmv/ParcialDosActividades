using CommunityToolkit.Mvvm.ComponentModel;
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
    }
}
