using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }
        // bring in Foreign Keys for both User and Movies
        public int UserId { get; set; }
        //fan
        public User Member { get; set; }
        public int  TheActivityId { get; set; }
        //fanOf
        public  TheActivity MemberOf { get; set; }
    }
}