using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Domain.Entities
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FristName {  get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public List<Movie> Movies { get; set; } = new();
    }
}
