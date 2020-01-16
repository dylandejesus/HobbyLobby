using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models
{
    public class Association
    {
        [Key]
        public int AssociationId { get; set; }
        public int UserID {get; set;}
        public int HobbyId {get;set;}
        public Hobby Hobbies {get;set;}
        public User Fan {get;set;}
    }
}