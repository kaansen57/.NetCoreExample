using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        //Loosely coupled , esnek bağlantı  , yani sadece imzaya (interface) ye bağlısın böylelikle manager(concrete)
        //değişssede bir sıkıtn oolmaz
        //IoC Container --- Inversion of Control
        ICarManager _carManager;
        public CarsController(ICarManager carManager)
        {
            _carManager = carManager;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependecy chain bağlımlılık zinciri car manager efcardal'a bağımlı
            //CarManager carManager = new CarManager(new EfCarDal());
            var result = _carManager.GetAll(1234);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carManager.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
