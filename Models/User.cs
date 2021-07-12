using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="Name with a minimum length of 2 characters")]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])|(?=.*?[a-z]))(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", 
        ErrorMessage = "Passwords must be at least 8 characters and contain at least 1 character,1 number and special character")]
        
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }
        // Navigation property for related WTheActivity and Participant objects
        public List<TheActivity> PostedActivity { get; set; }

        //likedMovis
        public List<Participant> AttendedActivity { get; set; }
    }
}