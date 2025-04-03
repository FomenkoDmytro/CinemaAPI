using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.DTO.Ganres
{
    public class MovieShortDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
