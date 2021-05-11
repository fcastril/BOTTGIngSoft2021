using BOTTGIngSoft2021.Data.Entities;
using System;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Repo.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Insert(T reg);
        void Update(T reg);
        void Delete(T reg);
        void Remove(T reg);
        void SaveChanges();
    }
}
