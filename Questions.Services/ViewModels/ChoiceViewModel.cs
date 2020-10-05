using System.ComponentModel.DataAnnotations;

namespace Questions.Services.ViewModels
{
    public class ChoiceViewModel
    {
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int Votes { get; set; }
    }
}