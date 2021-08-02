using System.ComponentModel.DataAnnotations;

namespace ERPAPI.Models
{
    public class UserForAuthentication
    {
        /// <summary>
        /// User name
        /// </summary>
        [Required(ErrorMessage = "Please enter name.")]
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
