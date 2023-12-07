using System.ComponentModel.DataAnnotations;

namespace EvoSystems.Models
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now.ToLocalTime();
    }
}
