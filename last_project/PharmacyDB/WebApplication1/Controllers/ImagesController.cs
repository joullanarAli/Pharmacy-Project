using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyDB.Interfaces;
using PharmacyDB.Models;

namespace PharmacyWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImagesController : BaseController
    {
        public ImagesController(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
        [HttpGet(Name ="GetAllImages")]
        public async Task<IActionResult> GetAllImages()
        {
            try
            {
                var images=(await _unitOfWork._imageRepository.GetAll()).Reverse().ToList();
                return Ok(images);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost(Name ="CreateImage")]
        public async  Task<IActionResult> CreateImage(Image image)
        {
            try
            {
                await _unitOfWork._imageRepository.Add(image);
                _unitOfWork.SaveChanges();
                var images=(await _unitOfWork._imageRepository.GetAll()).Reverse().ToList();
                return Ok(images);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut(Name ="UpdateImage")]
        public async Task<IActionResult> UpdateImage(int imageId,Image image)
        {
            try
            {
                Image _image = await _unitOfWork._imageRepository.GetById(imageId);
                _image.QuestionId = image.QuestionId;
                _image.Path = image.Path;
                _unitOfWork.SaveChanges();
                var images = (await _unitOfWork._imageRepository.GetAll()).Reverse().ToList();
                return Ok(images);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete(Name ="DeleteImage")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            try
            {
                Image image = await _unitOfWork._imageRepository.GetById(imageId);
                _unitOfWork._imageRepository.Delete(image);
                _unitOfWork.SaveChanges();
                var images = (await _unitOfWork._imageRepository.GetAll()).Reverse().ToList();
                return Ok(images);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
