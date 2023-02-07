using AutoMapper;
using hero.api.Dtos;
using hero.api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hero.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly HeroDbContext dbContext;

        public HeroeController(HeroDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HeroResponseDto>> Get()
        {
            var heroes = dbContext.Heroes.ToList();
            var response = mapper.Map<HeroResponseDto>(heroes);
            response.Message = "Consulta Exitosa";
            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post([FromBody] HeroRequestDto heroRequest)
        {
            var hero = mapper.Map<Hero>(heroRequest);
            dbContext.Heroes.Add(hero);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
