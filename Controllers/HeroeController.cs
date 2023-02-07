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
        public ActionResult<IEnumerable<Hero>> Get()
        {
            return Ok(dbContext.Heroes.ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Hero hero)
        {
            dbContext.Heroes.Add(hero);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
