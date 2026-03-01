using DataBindingExample.ViewModels;

namespace DataBindingExample.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new AirlinesViewModel();
        }
    }
}
