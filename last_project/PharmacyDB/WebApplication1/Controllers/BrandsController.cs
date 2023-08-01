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
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BrandsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : base(unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet(Name = "GetAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var brands = (await _unitOfWork._brandRepository.GetAll()).Reverse().ToList();
               /* foreach (var brand in brands)
                {
                    brand.FormFile=convertToFile(brand.Image);
                }*/
                return StatusCode((int)HttpStatusCode.OK,brands);
            }catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest,ex.Message);
            }
        }
        [HttpGet("GetBrandImage")]
        public async Task<IActionResult> GetBrandsImage(int id)
        {
            try
            {
                var brand = (await _unitOfWork._brandRepository.GetById(id));

                //  brand.FormFile = convertToFile(brand.Image);
                string filePath = "localhost:5191\\Images\\Brands\\" + brand.Image;
                return StatusCode((int)HttpStatusCode.OK, filePath);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [NonAction]
       IFormFile convertToFile(string fileName)
        {
            using (var stream = System.IO.File.OpenRead(fileName))
            {
                /* Brand  _brand= new Brand
                 {
                     Name = brand.Name,
                     Image = brand.Image,
                     FormFile = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                 };*/
                IFormFile formFile = new FormFile(stream, 0, stream.Length, null, fileName)
                {
                    Headers = new HeaderDictionary(),
                    //ContentDisposition= "image",
                    //ContentType = "image"
                };

                return formFile;
            }
        }
        [HttpPost(Name = "CreateBrand")]
        public async Task<IActionResult> CreateBrand(string brandName,IFormFile formFile)
        {
            try
            {
               // string filePath= UploadFile(formFile);
                string fileName= UploadFile(formFile);

                Brand brand = new Brand()
                {
                    Name = brandName,
                    Image = fileName,
                    //Image = filePath,
                    FormFile=formFile
                   // Image = formFile
                };
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

       /* string fileName = null;
            if (productViewModel.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "img");
        fileName = Guid.NewGuid().ToString() + "-" + productViewModel.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    productViewModel.Image.CopyTo(fileStream);
                }*/
     //   [HttpPost("UploadImage")]
       /* public async Task<IActionResult> UploadImage(IFormFile formFile)
        {
            //APIResponse apiResponse = new APIResponse();
            bool Results = false;
            try
            {
                var _uploadedFiles = Request.Form.Files;
                foreach (IFormFile source in _uploadedFiles)
                {
                    //string fileName = source.FileName;
                    string fileName = Guid.NewGuid().ToString() + "-" + source.FileName;
                    string filePath = getFilePath(fileName);
                    if (!System.IO.File.Exists(filePath))
                    {
                        System.IO.Directory.CreateDirectory(filePath);
                    }
                   // string imagePath=filePath+
                   using(FileStream stream = System.IO.File.Create(filePath))
                    {
                        await source.CopyToAsync(stream);
                        Results = true;
                    }
                }
            }catch(Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
            return Ok(Results);
        }*/

       /* [NonAction]
        private string getFilePath(string fileName)
        {

            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images","Brands");
            return uploadDir;
        }*/
        [NonAction]
        private string UploadFile(IFormFile formFile)
        {
            string fileName = null;
            string filePath=null;
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
            return fileName;
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
