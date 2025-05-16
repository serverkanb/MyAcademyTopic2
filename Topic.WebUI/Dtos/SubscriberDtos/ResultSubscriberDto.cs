using System.ComponentModel.DataAnnotations;

namespace Topic.WebUI.Dtos.SubscriberDtos
{
    public class ResultSubscriberDto
    {
        public int SubscriberId { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; } 
        public DateTime? SubscribedDate { get; set; } = DateTime.Now;
    }
}
