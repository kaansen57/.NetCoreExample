using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Polymorphism
{
    class ConnectionManager
    {
        public void Add(IConnectionDal connectionDal)
        {
            connectionDal.Insert();
        }

        public void Remove(IConnectionDal connectionDal)
        {
            connectionDal.Delete();
        }

        public void Update(IConnectionDal connectionDal)
        {
            connectionDal.Update();
        }
    }
}
