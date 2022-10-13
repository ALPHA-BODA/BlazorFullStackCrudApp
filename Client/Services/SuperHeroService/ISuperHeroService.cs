using BlazorFullStackCrudApp.Shared;

namespace BlazorFullStackCrudApp.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> heroes { get; set; }
        List<Comic> comics { get; set; }
        Task GetComics();
        Task GetSuperHeroes();
        Task<SuperHero> GetSingleHero(int id);
        Task CreateHero(SuperHero hero);
        Task UpdateHero(SuperHero hero);

        Task DeleteHero(int id);


    }
}
