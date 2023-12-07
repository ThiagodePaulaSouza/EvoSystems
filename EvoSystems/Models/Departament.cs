using System.ComponentModel.DataAnnotations;

namespace EvoSystems.Models
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abbreviation { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now.ToLocalTime();
    }
}
