using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;
using System.Net;

namespace PharmacyWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExamsController : BaseController
    {
        public ExamsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        [HttpGet(Name ="GetAllExams")]
        public async Task<IActionResult> GetAllExams()
        {
            try
            {
                var exams=(await _unitOfWork._examRepository.GetAll()).Reverse().ToList();
                return Ok(exams);
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost(Name = "CreateExam")]
        public async Task<IActionResult> CreateExam(Exam exam)
        {
            try
            {
                await _unitOfWork._examRepository.Add(exam);
                _unitOfWork.SaveChanges();
                var exams = (await _unitOfWork._examRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(exams) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
        [HttpPut(Name ="UpdateExam")]
        public async Task<IActionResult> UpdateExam(int examId,Exam exam)
        {
            try
            {
                Exam _exam = await _unitOfWork._examRepository.GetById(examId);
                _exam.Name = exam.Name;
                _exam.ExamDate = exam.ExamDate;
                _unitOfWork.SaveChanges();
                var exams = (await _unitOfWork._examRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(exams) { StatusCode = (int)HttpStatusCode.OK};
            }catch (Exception ex)
            {
                return new ObjectResult(ex) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
        [HttpDelete(Name ="DeleteExam")]
        public async Task<IActionResult> DeleteExam(int examId)
        {
            try
            {
                Exam exam = await _unitOfWork._examRepository.GetById(examId);
                _unitOfWork._examRepository.Delete(exam);
                _unitOfWork.SaveChanges();
                var exams = (await _unitOfWork._examRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(exams) { StatusCode = (int)HttpStatusCode.OK };
            }catch (Exception ex)
            {
                return new ObjectResult(ex) { StatusCode= (int)HttpStatusCode.BadRequest };
            }
        }
    }
}
