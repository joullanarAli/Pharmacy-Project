using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;

namespace PharmacyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : BaseController
    {
        public QuestionsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        [HttpGet(Name ="GetAllQuestions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var questions= (await _unitOfWork._questionRepository.GetAll()).Reverse().ToList();
                return Ok(questions);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost(Name ="CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(Question question)
        {
            try
            {
               await _unitOfWork._questionRepository.Add(question);
                _unitOfWork.SaveChanges();
                var questions= (await _unitOfWork._questionRepository.GetAll()).Reverse().ToList();
                return Ok(questions);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut(Name ="UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion(int questionId,Question question)
        {
            try
            {
                Question _question = await _unitOfWork._questionRepository.GetById(questionId);
                _question.NoAnswerMark = question.NoAnswerMark;
                _question.QuestionText = question.QuestionText;
                _question.WrongAnswerMark = question.WrongAnswerMark;
                _question.CourseId = question.CourseId;
                _unitOfWork.SaveChanges();
                var questions = (await _unitOfWork._questionRepository.GetAll()).Reverse().ToList();
                return Ok(questions);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete(Name ="DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            try
            {
                Question question = await _unitOfWork._questionRepository.GetById(questionId);
                _unitOfWork._questionRepository.Delete(question);
                _unitOfWork.SaveChanges();
                var questions = (await _unitOfWork._questionRepository.GetAll()).Reverse().ToList();
                return Ok(questions);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
