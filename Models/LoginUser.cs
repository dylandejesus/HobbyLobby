using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name="UserName: ")]

        public string LogInUser {get; set;}
        [Required]
        [Display(Name="Password: ")]
        [DataType(DataType.Password)]
        public string LogInPassword {get; set;}
    }
}