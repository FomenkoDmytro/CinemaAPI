using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicVision.Application_BLL.DTO.Audiences
{
    public class GetAllAudiencesDictionaryDto
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
