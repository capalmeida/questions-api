using System.ComponentModel.DataAnnotations;

namespace Questions.Domain.Models
{
    public class Choice
    {
        [Key]
        public int Id { get; set; }
        
        public int QuestionId { get; set; }
        
        public string Description { get; set; }

        public int Votes { get; set; }
    }
}