using DiceRoller.ViewModel;

namespace DiceRoller
{
    public partial class Details : ContentPage
    {
        public Details(DetailsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}