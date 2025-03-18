
using System.ComponentModel.DataAnnotations;

namespace EpicVision.Domain.Entities
{
    internal class Users
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email {  get; set; }

        public int? RoleId { get; set; }
        public UserRoles? Roles { get; set; }
    }
}
