using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BeltExam.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId {get;set;}
        [Required]
        [Display(Name="Name: ")]
        public string HobbyName {get; set;}
        [Required]
        [MinLength(10)]
        [Display(Name="Description: ")]
        public string Description {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public List<Association> Enthusiasts {get;set;}
        

    }
}