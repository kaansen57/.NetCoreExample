using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageManager
    {
        IResult Add(CarImage entity);
        IResult Delete(CarImage entity);
        IResult Update(CarImage entity);
        IDataResult<List<CarImage>> GetAllList(int id);
        IDataResult<CarImage> Get(int id);
    }
}
