using System.ComponentModel.DataAnnotations;

namespace TeaShop.Presentation.Models
{
    public class RegisterViewModel
    {
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
