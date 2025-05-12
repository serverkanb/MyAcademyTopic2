using System.ComponentModel.DataAnnotations;

namespace Topic.WebUI.Dtos.SubscriberDtos
{
    public class CreateSubscriberDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
