using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        IWebHostEnvironment _environment;
        ICarImageManager _carImageManager;
        public ImageController(ICarImageManager carImageManager, IWebHostEnvironment environment)
        {
            _carImageManager = carImageManager;
            _environment = environment;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile formFile)
        {

            if (formFile.Length > 0)
            {
                if (!Directory.Exists(_environment.WebRootPath + @"\Uploads\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + @"\Uploads\");
                }

                string guidKey = Guid.NewGuid().ToString("N");
                using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + GuidFileCreate(formFile, guidKey)))
                {
                    /*formdan gelen datayı belleğe yazıp oradan oluşturduğumuz dosyaya
                     * yazma işlemi yapıyoruz , ve bundan sonra cachede durması performans
                     * sorunları yaratacağıdan flush ile cache i temizliyoruz.
                     */
                   
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();

                    carImage.Date = DateTime.Now;
                    carImage.ImagePath = GuidFileCreate(formFile, guidKey);

                    var result = _carImageManager.Add(carImage);
                    if (result.Success)
                    {
                        return Ok(result.Message);
                    }
                    return BadRequest(result.Message);
                }
            }
            else
            {
                return BadRequest(Messages.FileNotRead);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage entity)
        {
            var result = _carImageManager.Delete(entity);
            if (result.Success)
            {
                System.IO.File.SetAttributes(_environment.WebRootPath + entity.ImagePath, FileAttributes.Normal);
                System.IO.File.Delete(_environment.WebRootPath + entity.ImagePath);
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm] CarImage entity, [FromForm] IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                if (!Directory.Exists(_environment.WebRootPath + @"\Uploads\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + @"\Uploads\");
                }
            }
            string guidKey = Guid.NewGuid().ToString("N");
            using (FileStream  fileStream = System.IO.File.Create(_environment.WebRootPath + GuidFileCreate(formFile,guidKey)))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();

                entity.ImagePath = GuidFileCreate(formFile, guidKey);
                entity.Date = DateTime.Now;

                var result = _carImageManager.Update(entity);

                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll([FromForm]int id)
        {
            var result = _carImageManager.GetAllList(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest();
        }
        private string GuidFileCreate(IFormFile formFile, string guidKey)
        {
            var fileType = "." + formFile.ContentType.Split('/')[1];
            return @"\Uploads\" + guidKey + fileType;
        }
    }
}

