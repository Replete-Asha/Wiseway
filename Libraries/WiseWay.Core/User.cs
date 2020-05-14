using System.ComponentModel.DataAnnotations;

namespace WiseWay.Core
{
    public class User
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }

        public string Token { get; set; }
      
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
