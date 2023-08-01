using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;
using System.Net;

namespace PharmacyWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        [HttpGet (Name="GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var brands = (await _unitOfWork._categoryRepository.GetAll()).Reverse().ToList();
                return StatusCode((int)HttpStatusCode.OK, brands);
            }catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPost(Name ="AddCategory")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            try
            {
                await _unitOfWork._categoryRepository.Add(category);
                _unitOfWork.SaveChanges();
                var categories = (await _unitOfWork._categoryRepository.GetAll()).Reverse().ToList();
                foreach (var _category in categories)
                {
                    _category.Drugs=new HashSet<Drug>();
                }
                return StatusCode((int)HttpStatusCode.OK,categories);
            }catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest,ex);
            }
        }
        [HttpPut(Name ="UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(int categoryId,Category _category)
        {
            try
            {
                Category category=await _unitOfWork._categoryRepository.GetById(categoryId);
                category.Name=_category.Name;
                _unitOfWork.SaveChanges();
                var categories = (await _unitOfWork._categoryRepository.GetAll()).Reverse().ToList();
                return StatusCode((int)HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpDelete(Name ="DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                Category category = await _unitOfWork._categoryRepository.GetById(categoryId);
                _unitOfWork.SaveChanges();
                var categories = (await _unitOfWork._categoryRepository.GetAll()).Reverse().ToList();
                return StatusCode((int)HttpStatusCode.OK, categories);
            }catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
