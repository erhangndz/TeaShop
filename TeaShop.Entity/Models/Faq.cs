using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop.Entity.Models
{
    public class Faq
    {
        public int FaqId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

    }
}
