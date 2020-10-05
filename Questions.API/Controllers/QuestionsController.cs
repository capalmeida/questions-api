using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questions.Domain.Models;
using Questions.Services.Interfaces;
using Questions.Services.ViewModels;

namespace Questions.API.Controllers
{
    /// <inheritdoc />
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        /// <summary>
        /// Questions Controller
        /// </summary>
        /// <param name="questionService"></param>
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /// <summary>
        /// Get all questions
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/questions")]
        [ProducesResponseType(typeof(IEnumerable<Question>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([Required] int skip, [Required] int take, string filter)
        {
            var questions = await _questionService.GetQuestionsAsync(skip, take, filter);
            
            return Ok(new
            {
                success = true, 
                questions
            });
        }
        
        /// <summary>
        /// Get one question
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/questions/{id}")]
        [ProducesResponseType(typeof(Question), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetQuestion([Required] int id)
        {
            var question = await _questionService.GetQuestionAsync(id);
            
            if(question != null)
                return Ok(new
                {
                    success = true,
                    question
                });

            return Ok(new
            {
                success = false,
                data = "No question found with the given id."
            });
        }
        
        /// <summary>
        /// Creates a question
        /// </summary>
        /// <param name="questionViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/questions")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(QuestionViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(QuestionViewModel questionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false
                });
            }

            var id = await _questionService.CreateAsync(questionViewModel);

            return Ok(new
            {
                success = true,
                id
            });
        }
        
        /// <summary>
        /// Updates a question
        /// </summary>
        /// <param name="questionViewModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("/api/questions")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateQuestionViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(UpdateQuestionViewModel questionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false
                });
            }
            
            var updatedQuestion = await _questionService.UpdateAsync(questionViewModel);

            return Ok(new
            {
                success = true,
                data = updatedQuestion
            });
        }

    }
}