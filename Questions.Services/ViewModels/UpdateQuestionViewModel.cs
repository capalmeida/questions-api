using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questions.Services.ViewModels
{
    public class UpdateQuestionViewModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }
        
        [Required]
        [Url]
        public string ThumbUrl { get; set; }

        [Required]
        public List<ChoiceViewModel> Choices { get; set; }
    }
}