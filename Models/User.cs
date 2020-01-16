using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BeltExam.Models;

namespace BeltExam.Models
{
    public class User
    {
        [Key]
        public int UserID {get; set;}
        [Required]
        [Display(Name = "First Name: ")]
        [MinLength(2, ErrorMessage= "Must have at least 2 characters")]
        public string FirstName {get; set;}
        [Required]
        [Display(Name = "Last Name: ")]
        [MinLength(2, ErrorMessage= "Must have at least 2 characters")]
        public string LastName {get; set;}
        [Required]
        [Display(Name = "UserName: ")]
        [MinLength(3, ErrorMessage= "Must be between 3 - 15 characters")]
        [MaxLength(15, ErrorMessage= "Must be between 3 - 15 characters" )]

        public string UserName {get; set;}
        [Required]
        [Display(Name = "Password: ")]
        [MinLength(8, ErrorMessage= "Must have at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        [Required]
        [Display(Name = "Confirm Password: ")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ComparePassword {get; set;}

        public List<Hobby> CoolHobbies {get; set;}
        public List<Association> NumOfEnthusiasts {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}