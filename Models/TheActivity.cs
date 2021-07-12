using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class TheActivity
    {
        [Key]
        
        public int TheActivityId { get; set; }
        
        [Required]
        public string Title { get; set; }
         [Required]
        
        public string Description { get; set; }
        
        
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        
        [Display(Name = "Duration")]
        public int Duration { get; set; }
        public string DurationState { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // Foreign Key for UserId has to match the property name in User class
        public int UserId { get; set; }
        public User CreatedBy { get; set; }
        

        //fans
        public List<Participant> Members  { get; set; }
    }
}