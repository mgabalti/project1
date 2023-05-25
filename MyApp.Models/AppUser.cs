using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class AppUser : IdentityUser
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public string user_email { get; set; }
        [Required]
        public string user_username { get; set; }
        [Required]
        public string user_password { get; set; }
        public DateTime user_regDate { get; set; }
        public DateTime? user_lastLogin { get; set; }
        public DateTime user_DateOfBirth { get; set; }
        [Required]
        public string user_Gender { get; set; }
        public string user_Country { get; set; }
        [Required]
        public string user_Phone { get; set; }

    }
}
