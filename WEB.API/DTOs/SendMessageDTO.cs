
using System.ComponentModel.DataAnnotations;

namespace WEB.API.DTOs
{
    public class SendMessageDTO
    {
        [Required]
        public string Message { get; set; }
    }
}
