using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint
    //class referans tip olur demek 
    //IEntity olabilir veya IEntity implement eden birsey olabilir
    //new(): new lenebilir olmaıdır
    //Sistemin sadece veritabanı nesneleri ile calısabilir bir yapı olması saglandı 
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        //manager sınıflarda expression yazabilmemizi saglayacak
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Update(T entitiy);
        void Delete(T entity);

    }
}
