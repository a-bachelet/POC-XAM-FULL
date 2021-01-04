using PocXamFull.Entities;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocXamFull.Repositories
{
    public class RickMortyApi : IRickMortyApi
    {
        public IRickMortyApi RefitImpl = RestService.For<IRickMortyApi>("https://rickandmortyapi.com/api");

        public Task<CharactersResponse> GetCharacters(int page)
        {
            return RefitImpl.GetCharacters(page);
        }
    }
}
