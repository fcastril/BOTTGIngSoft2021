using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BOTTGIngSoft2021.Repo.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BOTTGIngSoft2021Context context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(BOTTGIngSoft2021Context context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Add(reg);
            context.SaveChanges();
        }
        public void Update(T reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            context.Update(reg);
            context.SaveChanges();
        }
        public void Delete(T reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Remove(reg);
            context.SaveChanges();
        }

        public void Remove(T reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Remove(reg);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
