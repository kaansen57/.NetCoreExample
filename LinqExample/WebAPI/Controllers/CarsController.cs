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
    [Route("api/mapi/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        //Loosely coupled , esnek bağlantı  , yani sadece imzaya (interface) ye bağlısın
        ICarManager _carManager;
        public CarsController(ICarManager carManager)
        {
            _carManager = carManager;
        }
        [HttpGet]
        public List<Car> Get()
        {
            //Dependecy chain bağlımlılık zinciri car manager efcardal'a bağımlı
            //CarManager carManager = new CarManager(new EfCarDal());
            return _carManager.GetAll(1234).Data;
        }
    }
}
