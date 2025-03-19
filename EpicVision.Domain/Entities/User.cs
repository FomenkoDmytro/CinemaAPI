
using System.ComponentModel.DataAnnotations;

namespace EpicVision.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email {  get; set; }

        public bool IsActive { get; set; }

        public int? RoleId { get; set; }
        public UserRole? Roles { get; set; }
    }
}
