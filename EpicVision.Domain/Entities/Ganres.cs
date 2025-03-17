
using System.ComponentModel.DataAnnotations;


namespace EpicVision.Domain.Entities
{
    internal class Ganres
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
