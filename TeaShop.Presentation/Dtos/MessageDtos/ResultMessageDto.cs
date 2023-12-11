namespace TeaShop.Presentation.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
