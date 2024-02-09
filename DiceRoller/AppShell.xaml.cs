using DiceRoller.ViewModel;

namespace DiceRoller
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Details), typeof(Details));
        }
    }
}
