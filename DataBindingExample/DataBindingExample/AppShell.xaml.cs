namespace DataBindingExample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.AddAirlinePage), typeof(Views.AddAirlinePage));
        }
    }
}
