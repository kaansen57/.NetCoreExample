using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorManager
    {
        void Add(Color brand);
        void Delete(Color brand);
        void Update(Color brand);

        List<Color> GetAllList();

        Color GetColor(int colorId);
    }
}
