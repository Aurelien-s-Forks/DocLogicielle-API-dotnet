using System.ComponentModel.DataAnnotations;

namespace DocLogicielleAPI.DTO
{
    /// <summary>
    /// Voiture Model
    /// </summary>
    public class Voiture
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Puissance { get; set; }
    }
}