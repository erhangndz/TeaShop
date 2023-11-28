using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop.Dto.Dtos.FaqDtos
{
    public class UpdateFaqDto
    {
        public int FaqId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
