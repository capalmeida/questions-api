using System.Collections.Generic;
using System.Threading.Tasks;
using Questions.Domain.Models;
using Questions.Services.ViewModels;

namespace Questions.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<int> CreateAsync(QuestionViewModel questionViewModel);
        
        Task<Question> GetQuestionAsync(int id);

        Task<IEnumerable<Question>> GetQuestionsAsync(int skip, int take, string filter);
        
        Task<UpdateQuestionViewModel> UpdateAsync(UpdateQuestionViewModel questionViewModel);
    }
}