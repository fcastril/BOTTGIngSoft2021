using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BOTTGIngSoft2021.Repo.Repositories
{
    public class RepositoryIntent : IRepositoryIntent
    {
        private readonly BOTTGIngSoft2021Context context;
        private DbSet<Intent> entities;
        string errorMessage = string.Empty;

        public RepositoryIntent(BOTTGIngSoft2021Context context)
        {
            this.context = context;
            entities = context.Set<Intent>();
        }
        public IEnumerable<Intent> GetAll()
        {
            return entities.AsEnumerable();
        }
        public Intent Get(int id)
        {
            return entities.SingleOrDefault(s => s.CodeId == id);
        }
        public Intent Get(string id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public Intent GetName(string value)
        {
          
            var result = entities.Where(x=>x.Name==value).FirstOrDefault();
            return result;
        }
        public void Insert(Intent reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Add(reg);
            context.SaveChanges();
        }
        public void Update(Intent reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            context.Update(reg);
            context.SaveChanges();
        }
        public void Delete(Intent reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Remove(reg);
            context.SaveChanges();
        }

        public void Remove(Intent reg)
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
