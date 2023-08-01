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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> CreateCategoty(string categoryName, IFormFile formFile)
        {
            try
            {
                string filePath = UploadFile(formFile);
                Category category = new Category()
                {
                    Name = categoryName,
                    Image = filePath,
                    ImageFile = formFile
                    // Image = formFile
                };
                await _unitOfWork._categoryRepository.Add(category);
                _unitOfWork.SaveChanges();
                var categories = (await _unitOfWork._categoryRepository.GetAll()).Reverse().ToList();
                for (int i = 0; i < categories.Count(); i++)
                {
                    categories[i].Drugs = new HashSet<Drug>();
                }
                return new ObjectResult(categories) { StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
        }

        [NonAction]
        private string UploadFile(IFormFile formFile)
        {
            string fileName = null;
            string filePath = null;
            if (formFile != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Brands");
                fileName = Guid.NewGuid().ToString() + "-" + formFile.FileName;
                filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
                //Console.WriteLine(filePath);
            }
            return filePath;
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
                _unitOfWork._categoryRepository.Delete(category);
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
