using System.ComponentModel.DataAnnotations;

namespace EpicVision.Domain.Entities
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Role {  get; set; } = string.Empty;

        public List<User> Users { get; set; } = new();

    }
}
