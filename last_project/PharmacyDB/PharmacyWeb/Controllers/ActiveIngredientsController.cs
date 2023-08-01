using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;
using System.Net;

namespace PharmacyWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActiveIngredientsController : BaseController
    {
        public ActiveIngredientsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        [HttpGet(Name = "GetAllActiveIngredients")]
        public async Task<IActionResult> GetAllActiveIngredients()
        {
            try
            {
                var activeIngredients = (await _unitOfWork._activeIngredientRepository.GetAll()).Reverse().ToList();
                return StatusCode((int)HttpStatusCode.OK, activeIngredients);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost(Name = "CreateActiveIngredient")]
        public async Task<IActionResult> CreateActiveIngredient(ActiveIngredient activeIngredient)
        {
            try
            {
                await _unitOfWork._activeIngredientRepository.Add(activeIngredient);
                _unitOfWork.SaveChanges();
                var activeIngredients = (await _unitOfWork._activeIngredientRepository.GetAll()).Reverse().ToList();
               
                return new ObjectResult(activeIngredients) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
        [HttpPut(Name = "UpdateactiveIngredient")]
        public async Task<IActionResult> UpdateActiveIngredient(int activeIngredientId, ActiveIngredient _activeIngredient)
        {
            try
            {
                ActiveIngredient activeIngredient = await _unitOfWork._activeIngredientRepository.GetById(activeIngredientId);
                activeIngredient.Name = _activeIngredient.Name;
               // _unitOfWork._activeIngredientRepository.Update(activeIngredient);
                var activeIngredients = (await _unitOfWork._activeIngredientRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(activeIngredients) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }

        [HttpDelete(Name = "DeleteActiveIngredient")]
        public async Task<IActionResult> DeleteActiveIngredient(int activeIngredientId)
        {
            try
            {
                ActiveIngredient activeIngredient = await _unitOfWork._activeIngredientRepository.GetById(activeIngredientId);
                _unitOfWork._activeIngredientRepository.Delete(activeIngredient);
                _unitOfWork.SaveChanges();
                var activeIngredients = (await _unitOfWork._activeIngredientRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(activeIngredients) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
    }
}
