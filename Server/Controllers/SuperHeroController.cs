using BlazorFullStackCrudApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorFullStackCrudApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            this._context = context;
        }
       /* public static List<Comic> comics = new List<Comic>
        {
            new Comic { Id = 1, Name = "Marvel"},
            new Comic { Id = 2, Name = "DC"}

        };
        public static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                FirstName = "Peter",
                LastName = "Parker",
                HeroName = "Spiderman",
                Comic = comics[0],
                ComicId = 1,

            },
             new SuperHero
            {
                Id = 2,
                FirstName = "Bruce",
                LastName = "Wayne",
                HeroName = "Batman",
                Comic = comics[1],
                ComicId = 2,


            },

        };*/
      

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var heroes = await _context.superHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _context.comics.ToListAsync();

            return Ok(comics);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var hero = await _context.superHeroes.Include(h=>h.Comic).FirstOrDefaultAsync(h => h.Id == id);
            if(hero == null)
            {
                return NotFound("Sorry, No Hero here. :/");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> CreateSuperHero(SuperHero hero)
        {
             hero.Comic = null;
             _context.superHeroes.Add(hero);
             await _context.SaveChangesAsync();            
             return Ok(await GetDbHeroes());
        }




        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(SuperHero hero, int id)
        {
            var dbHero = await _context.superHeroes.Include(sh => sh.Comic).FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, but no Hero for you.  :/");
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.HeroName = hero.HeroName;
            dbHero.ComicId = hero.ComicId;
            await _context.SaveChangesAsync();



            return Ok(await GetDbHeroes());
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.superHeroes.Include(sh => sh.Comic).FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, but no Hero for you.  :/");
            _context.superHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();



            return Ok(await GetDbHeroes());
        }


































        private async Task <List<SuperHero>> GetDbHeroes()
        {
            return await _context.superHeroes.Include(sh => sh.Comic).ToListAsync();
        }

















    }
}
