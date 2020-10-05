using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Questions.Domain.Models;
using Questions.Services.Data;
using Questions.Services.Interfaces;
using Questions.Services.ViewModels;

namespace Questions.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly QuestionsContext _context;

        public QuestionService(IMapper mapper, QuestionsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> CreateAsync(QuestionViewModel questionViewModel)
        {
            var question = _mapper.Map<Question>(questionViewModel);
            
            await _context.Questions.AddAsync(question);
            _context.SaveChanges();

            return question.Id;
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await FetchQuestionAsync(id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync(int skip, int take, string filter)
        {
            var questions= await _context.Questions
                .Include(q => q.Choices)
                .AsNoTracking().Skip(skip).Take(take).ToListAsync();

            if (!string.IsNullOrEmpty(filter))
                questions = questions.Where(x => x.Description.Contains(filter)).ToList();
            
            return questions;
        }

        public async Task<UpdateQuestionViewModel> UpdateAsync(UpdateQuestionViewModel questionViewModel)
        {
            var updatedQuestion = _mapper.Map<Question>(questionViewModel);

            var question = await FetchQuestionAsync(updatedQuestion.Id);
            _context.Choice.RemoveRange(question.Choices);
            
            _context.Questions.Update(updatedQuestion);
            _context.SaveChanges();

            return _mapper.Map<UpdateQuestionViewModel>(updatedQuestion);
        }

        private async Task<Question> FetchQuestionAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Choices)
                .AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}