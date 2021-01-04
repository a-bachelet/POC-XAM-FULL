using PocXamFull.Repositories;
using PocXamFull.ViewModels;
using PocXamFull.Views;
using Prism;
using Prism.Ioc;
using Refit;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PocXamFull
{
    public partial class App
    {
        public App(IPlatformInitializer initializer): base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/Characters");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<Characters, CharactersViewModel>();
            containerRegistry.RegisterForNavigation<Character, CharacterViewModel>();

            containerRegistry.RegisterSingleton<IRickMortyApi, RickMortyApi>();
        }
    }
}
