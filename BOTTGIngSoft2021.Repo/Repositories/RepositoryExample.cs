using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BOTTGIngSoft2021.Repo.Repositories
{
    public class RepositoryExample : IRepositoryExample
    {
        private readonly BOTTGIngSoft2021Context context;
        private DbSet<Example> entities;
        string errorMessage = string.Empty;

        public RepositoryExample(BOTTGIngSoft2021Context context)
        {
            this.context = context;
            entities = context.Set<Example>();
        }
        public IEnumerable<Example> GetAll()
        {
            return entities.AsEnumerable();
        }
        public Example Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public Example Get(string nameIntent)
        {
            return entities.SingleOrDefault(s => s.IntentLabel == nameIntent);
        }
        public void Insert(Example reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Add(reg);
            context.SaveChanges();
        }
        public void Delete(Example reg)
        {
            if (reg == null)
            {
                throw new ArgumentNullException("reg");
            }
            entities.Remove(reg);
            context.SaveChanges();
        }

        public void Remove(Example reg)
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
