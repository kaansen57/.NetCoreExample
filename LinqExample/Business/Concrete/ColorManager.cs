using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorManager
    {
        private IColorDal _color;
        public ColorManager(IColorDal color)
        {
            _color = color;
        }
        public void Add(Color brand)
        {
            _color.Add(brand);
        }

        public void Delete(Color brand)
        {
            _color.Delete(brand);
        }

        public List<Color> GetAllList()
        {
            return _color.GetAll();
        }

        public Color GetColor(int colorId)
        {
            return _color.Get(c=>c.ColorId == colorId);
        }

        public void Update(Color brand)
        {
            //brand.ColorId = 12;
            //brand.ColorName = "Güncel Renk";
            _color.Update(brand);
        }




    }
}
