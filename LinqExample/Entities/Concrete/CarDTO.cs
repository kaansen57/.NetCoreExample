using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarDTO : IEntity
    {
        public int DailyPrice { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
    }
}
