using System.ComponentModel.DataAnnotations;

namespace Domain.Models.User
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The username can not be empty")]
        public required string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public required string UserPassword { get; set; }
    }
}
