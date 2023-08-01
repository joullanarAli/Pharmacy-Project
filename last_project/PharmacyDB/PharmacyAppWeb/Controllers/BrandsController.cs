using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;
using PharmacyInfrastructure.Repositories;
using System.Net;

namespace PharmacyWeb.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : BaseController
    {
        
      
        public BrandsController (IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        
        [HttpGet(Name = "GetAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var brands = (await _unitOfWork._brandRepository.GetAll()).Reverse().ToList();
                return StatusCode((int)HttpStatusCode.OK,brands);
            }catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest,ex.Message);
            }
        }
       
        [HttpPost(Name = "CreateBrand")]
        public async Task<IActionResult> CreateBrand(Brand brand)
        {
            try
            {
                await _unitOfWork._brandRepository.Add(brand);
                _unitOfWork.SaveChanges();
                var brands = (await _unitOfWork._brandRepository.GetAll()).Reverse().ToList();
                for (int i = 0; i < brands.Count(); i++)
                {
                    brands[i].Drugs = new HashSet<Drug>();
                }
                return new ObjectResult(brands) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }
        [HttpPut(Name ="UpdateBrand")]
        public async Task<IActionResult> UpdateBrand(int brandId,Brand _brand)
        {
            try
            {
                Brand brand=await _unitOfWork._brandRepository.GetById(brandId);
                brand.Name = _brand.Name;
              //  _unitOfWork._brandRepository.Update(brand);
                var brands=(await _unitOfWork._brandRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(brands) { StatusCode = (int)HttpStatusCode.OK};
            }catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode= (int)HttpStatusCode.BadRequest };
            }
        }

        [HttpDelete(Name ="DeleteBrand")]
        public async Task<IActionResult> DeleteBrand(int brandId)
        {
            try
            {
                Brand brand = await _unitOfWork._brandRepository.GetById(brandId);
                _unitOfWork._brandRepository.Delete(brand);
                _unitOfWork.SaveChanges();
                var brands = (await _unitOfWork._brandRepository.GetAll()).Reverse().ToList();
                return new ObjectResult(brands) { StatusCode = (int)HttpStatusCode.OK };
            }catch(Exception ex)
            {
                return new ObjectResult(ex.Message) {StatusCode= (int)HttpStatusCode.BadRequest};
            }
        }
    }
}
