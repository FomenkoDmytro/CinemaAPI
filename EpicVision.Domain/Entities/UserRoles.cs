using System.ComponentModel.DataAnnotations;

namespace EpicVision.Domain.Entities
{
    internal class UserRoles
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Role {  get; set; }

        public List<Users> Users { get; set; } = new();

    }
}
