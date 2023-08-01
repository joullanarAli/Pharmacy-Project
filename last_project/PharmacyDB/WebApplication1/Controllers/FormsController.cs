using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;
using System.Net;

namespace PharmacyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : BaseController
    {
        public FormsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        [HttpGet(Name = "GetAllForms")]
        public async Task<IActionResult> GetAllForms()
        {
            try
            {
                var forms = (await _unitOfWork._formRepository.GetAll()).Reverse().ToList();
                return StatusCode((int)HttpStatusCode.OK, forms);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost(Name = "CreateForm")]
        public async Task<IActionResult> CreateForm(Form form)
        {
            try
            {
                await _unitOfWork._formRepository.Add(form);
                _unitOfWork.SaveChanges();
                var forms = (await _unitOfWork._formRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(forms) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
        [HttpPut(Name = "UpdateForm")]
        public async Task<IActionResult> Updateform(int formId, Form _form)
        {
            try
            {
                Form form = await _unitOfWork._formRepository.GetById(formId);
                form.Name = _form.Name;
                //_unitOfWork._formRepository.Update(form);
                var forms = (await _unitOfWork._formRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(forms) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }

        [HttpDelete(Name = "DeleteForm")]
        public async Task<IActionResult> DeleteForm(int formId)
        {
            try
            {
                Form form = await _unitOfWork._formRepository.GetById(formId);
                _unitOfWork._formRepository.Delete(form);
                _unitOfWork.SaveChanges();
                var forms = (await _unitOfWork._formRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(forms) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
    }
}
