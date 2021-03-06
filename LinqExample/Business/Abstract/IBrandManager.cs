﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandManager
    {
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);

        List<Brand> GetAllList();

        Brand GetBrand(int brandId);
    }
}
