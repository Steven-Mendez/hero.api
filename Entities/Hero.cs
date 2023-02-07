using System.ComponentModel.DataAnnotations;

namespace hero.api.Entities
{
    public class Hero
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string SuperPower { get; set; } = "";
    }
}
