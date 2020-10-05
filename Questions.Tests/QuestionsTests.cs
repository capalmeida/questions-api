using System.Collections.Generic;
using Moq;
using Questions.Services.Interfaces;
using Questions.Services.ViewModels;
using Xunit;

namespace Questions.Tests
{
    public class QuestionsTests
    {
        [Fact]
        public void CreateQuestionTest()
        {
           var sut = new Mock<IQuestionService>();
           var question = GenerateQuestion();

           var id = sut.Setup(service => service.CreateAsync(question));
           
           Assert.NotNull(id);
        }
        
        [Fact]
        public void GetAllQuestions()
        {
            var sut = new Mock<IQuestionService>();
            var questions = sut.Setup(service => service.GetQuestionsAsync(0, 10, string.Empty));

            Assert.NotNull(questions);
        }
        
        [Fact]
        public void GetOneQuestions()
        {
            var sut = new Mock<IQuestionService>();
            var question = sut.Setup(service => service.GetQuestionAsync(1));
            
            Assert.NotNull(question);
        }
        
        [Fact]
        public void UpdateQuestionTest()
        {
            var sut = new Mock<IQuestionService>();
            var question = UpdatableQuestion();

            sut.Setup(service => service.UpdateAsync(question));
        }

        private static QuestionViewModel GenerateQuestion()
        {
            var question = new QuestionViewModel
            {
                Description = "Favourite programming language?",
                ImageUrl = "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                ThumbUrl = "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                Choices = new List<ChoiceViewModel>
                {
                    new ChoiceViewModel
                    {
                        Description = "Golang",
                        Votes = 100
                    },
                    new ChoiceViewModel
                    {
                        Description = "R",
                        Votes = 50
                    },
                    new ChoiceViewModel
                    {
                        Description = "C#",
                        Votes = 80
                    }
                }
            };

            return question;
        }
        
        private static UpdateQuestionViewModel UpdatableQuestion()
        {
            var question = new UpdateQuestionViewModel
            {
                Id = 1,
                Description = "Favourite programming language?",
                ImageUrl = "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)",
                ThumbUrl = "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)",
                Choices = new List<ChoiceViewModel>
                {
                    new ChoiceViewModel
                    {
                        Description = "Golang",
                        Votes = 100
                    },
                    new ChoiceViewModel
                    {
                        Description = "R",
                        Votes = 50
                    },
                    new ChoiceViewModel
                    {
                        Description = "C#",
                        Votes = 80
                    }
                }
            };

            return question;
        }
    }
}