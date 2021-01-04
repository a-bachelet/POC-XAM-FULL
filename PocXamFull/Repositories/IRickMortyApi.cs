using PocXamFull.Entities;
using Refit;
using System.Threading.Tasks;

namespace PocXamFull.Repositories
{
    public interface IRickMortyApi
    {
        [Get("/character?page={page}")]
        Task<CharactersResponse> GetCharacters([AliasAs("page")] int page);
    }
}
