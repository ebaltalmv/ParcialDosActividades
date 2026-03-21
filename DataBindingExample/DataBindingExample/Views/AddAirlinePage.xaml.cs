using DataBindingExample.Models;
using DataBindingExample.ViewModels;

namespace DataBindingExample.Views;

[QueryProperty("Airline", "Airline")]
public partial class AddAirlinePage : ContentPage
{
    private AirlineModel _airline;
    private readonly AirlineViewModel _airlineViewModel;
    public AddAirlinePage()
    {
        InitializeComponent();
        _airlineViewModel = new AirlineViewModel();
        BindingContext = _airlineViewModel;
    }

    public AirlineModel Airline
    {
        get => _airline; set
        {
            _airline = value;
            if (_airlineViewModel != null && value != null)
            {
                _airlineViewModel.LoadAirlineForEdition(value);
            }
        }
    }
}