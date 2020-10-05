using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questions.Domain.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public DateTime PublishedAt { get; set; }

        public List<Choice> Choices { get; set; }
    }
}