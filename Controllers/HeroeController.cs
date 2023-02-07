using hero.api.Dtos;
using hero.api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hero.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroeController : ControllerBase
    {
        private readonly HeroDbContext dbContext;

        public HeroeController(HeroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HeroResponseDto>> Get()
        {
            var response = new HeroResponseDto();
            var heroes = dbContext.Heroes;
            foreach (var hero in heroes)
            {
                response.Data.Add(hero);
            }
            response.Message = "Consulta Exitosa";

            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post([FromBody] HeroRequestDto heroRequest)
        {
            var hero = new Hero()
            {
                Name = heroRequest.Name,
                SuperPower = heroRequest.SuperPower,
            };
            dbContext.Heroes.Add(hero);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
