using hero.api.Entities;
using hero.api.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return Ok(new ApiResult() { Data = dbContext.Heroes.ToList(), Message = "Hero Information"});
        }

        [HttpPost]
        public ActionResult Post([FromBody] Hero hero)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResult() { IsError = true, Message = "Invalid Hero Information" });

            dbContext.Heroes.Add(hero);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Hero hero)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResult() { IsError = true, Message = "Invalid Hero Information" });

            var dbHero = dbContext.Heroes.FirstOrDefault(h => h.Id == hero.Id);

            if (dbHero is null)
                return BadRequest(new ApiResult() { IsError = true, Message = $"Hero with id {hero.Id} not found" });

            dbHero.Name = hero.Name;
            dbHero.SuperPower = hero.SuperPower;
            dbContext.Heroes.Update(dbHero);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Hero Information");

            var dbHero = dbContext.Heroes.FirstOrDefault(h => h.Id == id);

            if (dbHero is null)
                return BadRequest(new ApiResult() { IsError = true, Message = $"Hero with id {id} not found" });

            dbContext.Heroes.Remove(dbHero);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
