using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;
using System.Net;

namespace PharmacyWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : BaseController
    {
        public CoursesController (IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        [HttpGet(Name = "GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                var brands = (await _unitOfWork._courseRepository.GetAll()).Reverse().ToList();
                return StatusCode((int)HttpStatusCode.OK, brands);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost(Name = "CreateCourse")]
        public async Task<IActionResult> CreateBrand(Course course)
        {
            try
            {
                await _unitOfWork._courseRepository.Add(course);
                _unitOfWork.SaveChanges();
                var courses = (await _unitOfWork._courseRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(courses) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
        [HttpPut(Name = "UpdateCourse")]
        public async Task<IActionResult> UpdateCourse(int courseId, Course _course)
        {
            try
            {
                Course course = await _unitOfWork._courseRepository.GetById(courseId);
                course.Name = _course.Name;
               // _unitOfWork._courseRepository.Update(course);
                var courses = (await _unitOfWork._courseRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(courses) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }

        [HttpDelete(Name = "DeleteCourse")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            try
            {
                Course course = await _unitOfWork._courseRepository.GetById(courseId);
                _unitOfWork._courseRepository.Delete(course);
                _unitOfWork.SaveChanges();
                var courses = (await _unitOfWork._courseRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(courses) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
    }
}
