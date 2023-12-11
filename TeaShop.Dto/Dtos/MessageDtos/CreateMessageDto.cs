using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShop.Dto.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
