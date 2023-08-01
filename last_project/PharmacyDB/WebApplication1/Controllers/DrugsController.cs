using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;
using System.Net;

namespace PharmacyWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrugsController : BaseController
    {
        public DrugsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        [HttpGet(Name ="GetAllDrugs")]
        public async Task<IActionResult> GetAllDrugs()
        {
            try
            {
                var drugs = (await _unitOfWork._drugRepository.GetAll()).Reverse().ToList();
                return StatusCode((int)HttpStatusCode.OK, drugs);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost(Name = "CreateDrug")]
        public async Task<IActionResult> CreateDrug(Drug drug)
        {
            try
            {
                await _unitOfWork._drugRepository.Add(drug);
                _unitOfWork.SaveChanges();
                var drugs = (await _unitOfWork._drugRepository.GetAll()).Reverse().ToList();
                Brand brand = await _unitOfWork._brandRepository.GetById(drug.BrandId);
                Category category = await _unitOfWork._categoryRepository.GetById(drug.CategoryId);
                foreach(var drugsItem in drugs)
                {
                    drugsItem.Brand.Id = brand.Id;
                    drugsItem.Brand.Name = brand.Name;
                    drugsItem.Category.Id = category.Id;
                    drugsItem.Category.Name= category.Name;
                }
                return new ObjectResult(drugs) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
        [HttpPut(Name = "UpdateDrug")]
        public async Task<IActionResult> UpdateBrand(int drugId, Drug _drug)
        {
            try
            {
                Drug drug = await _unitOfWork._drugRepository.GetById(drugId);
                drug.ArabicName = _drug.ArabicName;
                drug.EnglishName = _drug.EnglishName;
                drug.SideEffects = _drug.SideEffects;
                drug.Image = _drug.Image;
                drug.Description = _drug.Description;
                _unitOfWork._drugRepository.Update(drug);
                var drugs = (await _unitOfWork._drugRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(drugs) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }

        [HttpDelete(Name = "DeleteDrug")]
        public async Task<IActionResult> DeleteDrug(int drugId)
        {
            try
            {
                Drug drug = await _unitOfWork._drugRepository.GetById(drugId);
                _unitOfWork._drugRepository.Delete(drug);
                _unitOfWork.SaveChanges();
                var drugs = (await _unitOfWork._drugRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(drugs) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
    }
}
