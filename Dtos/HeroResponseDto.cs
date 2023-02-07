using hero.api.Entities;

namespace hero.api.Dtos
{
    public class HeroResponseDto
    {
        public string? Message { get; set; }
        public List<object> Data { get; set; } = new List<object>();
    }
}
