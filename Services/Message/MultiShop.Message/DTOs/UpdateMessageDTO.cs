namespace MultiShop.Message.DTOs
{
    public class UpdateMessageDTO
    {
        public int UserMessageID { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
