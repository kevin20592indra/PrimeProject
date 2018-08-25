using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using log4net;
using PrimeProject.Business.Application.Utils;
using PrimeProject.Business.EntityFramework;

namespace PrimeProject.Business.Application.Manager
{
    public class ModuleManager<T> where T : class
    {
        public static ILog log = LogManager.GetLogger(typeof(T).Name);

        private DbSet<T> module;

        protected PrimeContext PrimeContext
        {
            get
            {
                return PrimeDbContext.GetDbContext();
            }
        }

        protected DbSet<T> Module
        {
            get
            {
                module = PrimeContext.Set<T>();
                return module;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return Module.AsQueryable();
        }

        public virtual T GetById(Guid id)
        {
            return Module.Find(id);
        }

        public virtual void Insert(T obj)
        {
            Module.Add(obj);
            Save();
        }

        public virtual void Insert(IEnumerable<T> obj)
        {
            Module.AddRange(obj);
            Save();
        }

        public virtual void Update(T obj, Guid id)
        {
            var objToUpdate = Module.Find(id);
            if (objToUpdate != null)
            {
                ReflectionUtils.CopyObject(obj, objToUpdate);
                Save();
            }
        }

        public virtual void Delete(Guid id)
        {
            var objToDelete = Module.Find(id);
            if (objToDelete != null)
            {
                Module.Remove(objToDelete);
                Save();
            }
        }

        public virtual void Delete(IEnumerable<T> obj)
        {
            Module.RemoveRange(obj);
            Save();
        }

        public virtual void Save()
        {
            PrimeContext.SaveChanges();
        }
    }
}
