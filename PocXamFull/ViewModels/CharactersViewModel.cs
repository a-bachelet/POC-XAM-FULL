using PocXamFull.Entities;
using PocXamFull.Repositories;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PocXamFull.ViewModels
{
    public class CharactersViewModel : ViewModelBase
    {
        private IRickMortyApi _api;

        private ObservableCollection<Character> _characters;

        private int _missingCharactersCount = 1;

        private int _page = 1;

        private bool _loading = false;

        public Command GoToCharacterPageCommand { get; private set; }

        public Command CharactersThresholdReachedCommand { get; private set; }

        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set { SetProperty(ref _characters, value); }
        }

        public int MissingCharactersCount
        {
            get { return _missingCharactersCount; }
            set { SetProperty(ref _missingCharactersCount, value); }
        }

        public bool Loading
        {
            get { return _loading; }
            set { SetProperty(ref _loading, value); }
        }

        public Character SelectedCharacter { get; set; }

        public CharactersViewModel(INavigationService navigationService, IRickMortyApi api): base(navigationService)
        {
            _api = api;

            Title = "Characters";

            GoToCharacterPageCommand = new Command(() => {
                var navParameters = new NavigationParameters();

                navParameters.Add("id", SelectedCharacter.Id);

                navigationService.NavigateAsync("Character", navParameters);

                SelectedCharacter = null;
            });

            CharactersThresholdReachedCommand = new Command(() =>
            {
                if ( MissingCharactersCount > 0 )
                {
                    LoadCharacters();
                }
            });

            Characters = new ObservableCollection<Character>();

            LoadCharacters();
        }

        public async void LoadCharacters()
        {
            if ( !Loading )
            {
                Loading = true;

                var characters = await _api.GetCharacters(_page);

                characters.Results.ForEach(c => Characters.Add(c));

                if (!String.IsNullOrEmpty(characters.Info.Next))
                {
                    _page += 1;
                    MissingCharactersCount = 1;
                }
                else
                {
                    MissingCharactersCount = 0;
                }

                Loading = false;
            }
        }
    }
}
