using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //class: referans tip olabilir demek
    //Ientity olabilir veya Ientityden türeyen bir nesne olabilir.
    //new() , new lenebilir olmalı , interface new lenemez , bu yüzden interface kabul edilmeyecek. sadece class kabul edilecek
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T car);
        void Delete(T car);
        void Update(T car);

        //List<T> GetAll();
        
    }
}
