using BOTTGIngSoft2021.Data.Entities;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Repo.Interfaces
{
    public interface IRepositoryExample
    {
        IEnumerable<Example> GetAll();
        Example Get(long id);
        Example Get(string nameIntent);
        void Insert(Example reg);
        void Delete(Example reg);
        void Remove(Example reg);
        void SaveChanges();
    }
}
