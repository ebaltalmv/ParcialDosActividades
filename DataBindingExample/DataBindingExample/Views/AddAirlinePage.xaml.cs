using DataBindingExample.ViewModels;

namespace DataBindingExample.Views;

public partial class AddAirlinePage : ContentPage
{
    public AddAirlinePage()
    {
        InitializeComponent();
        BindingContext = new AirlineViewModel();
    }
}