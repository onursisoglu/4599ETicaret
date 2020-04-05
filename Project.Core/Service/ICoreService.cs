using Project.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Service
{
   public interface ICoreService<T> where T:CoreEntity
    {
        int Add(T item);

        int Update(T item);

        bool Remove(T item);

        bool Remove(int id);

        List<T> GetAll(); // Bu metot T tipine gelen tablodaki tüm verileri getirir.

        List<T> GetActive();// // Bu metot T tipine gelen tablodaki IsActive property' si true olan verileri getirir.

        List<T> GetDefault(Expression<Func<T, bool>> exp); // parametre olarak lambda sorgusu (ifadesi) alır. 

        T GetByID(int id);

        T GetByDefault(Expression<Func<T, bool>> exp);

        int Save();

    }
}
