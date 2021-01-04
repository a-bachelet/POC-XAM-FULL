using Prism.Navigation;

namespace PocXamFull.ViewModels
{
    public class CharacterViewModel : ViewModelBase
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        public CharacterViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Character";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            Id = parameters.GetValue<int>("id");
        }
    }
}
