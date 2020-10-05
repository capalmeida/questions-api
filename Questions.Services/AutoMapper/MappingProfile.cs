using AutoMapper;
using Questions.Domain.Models;
using Questions.Services.ViewModels;

namespace Questions.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Choice, ChoiceViewModel>();
            CreateMap<ChoiceViewModel, Choice>();
            
            CreateMap<Question, QuestionViewModel>();
            CreateMap<QuestionViewModel, Question>();
            
            CreateMap<Question, UpdateQuestionViewModel>();
            CreateMap<UpdateQuestionViewModel, Question>();
        }
    }
}