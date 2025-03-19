using System.ComponentModel.DataAnnotations;


namespace EpicVision.Domain.Entities
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public TimeOnly Time { get; set; }

        
        public int HallId { get; set; }
        public Hall? Hall { get; set; }
    }
}
