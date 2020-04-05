using Project.Core.Entity;
using Project.Core.Service;
using Project.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Base
{
    public class BaseService<K> : ICoreService<K> where K : CoreEntity
    {

        ProjectContext db;

        public BaseService()
        {
            db = new ProjectContext();
        }



        public int Add(K item)
        {
            item.CreatedDate = DateTime.Now;
            item.CreatedUserName = Environment.UserName;
            item.CreatedComputerName = Environment.MachineName;
            item.IsActive = true;
            db.Set<K>().Add(item);
           return Save();
        }

        public List<K> GetActive()
        {
            return db.Set<K>().Where(x => x.IsActive).ToList();
        }

        public List<K> GetAll()
        {
            return db.Set<K>().ToList();
        }

        public K GetByDefault(Expression<Func<K, bool>> exp)
        {
            return db.Set<K>().FirstOrDefault(exp);
        }

        public K GetByID(int id)
        {
            var bulunanNesne = db.Set<K>().Find(id);
            return bulunanNesne;
        }

        public List<K> GetDefault(Expression<Func<K, bool>> exp)
        {
            return db.Set<K>().Where(exp).ToList();
        }

        public bool Remove(K item)
        {
            if(item!=null)
            {
                item.IsActive = false;
                Save();
                return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            try
            {
                var bulunanNesne = GetByID(id);
               
                    bulunanNesne.IsActive = false;
                    Save();
                    return true;
               
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(K item)
        {
            // Önce veritabanındaki orjinal halini bulalım. 
            K orjinalVeri = GetByID(item.ID);
            item.CreatedDate = orjinalVeri.CreatedDate;
            item.CreatedComputerName = orjinalVeri.CreatedComputerName;
            item.CreatedUserName = orjinalVeri.CreatedUserName;
            item.ModifiedDate = DateTime.Now;
            item.ModifiedComputerName = Environment.MachineName;
            item.ModifiedUserName = Environment.UserName;

            return Save();
            
        }
    }
}
