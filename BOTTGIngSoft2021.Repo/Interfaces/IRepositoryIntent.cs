using BOTTGIngSoft2021.Data.Entities;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Repo.Interfaces
{
    public interface IRepositoryIntent
    {
        IEnumerable<Intent> GetAll();
        Intent Get(int id);
        Intent Get(string id);
        Intent GetName(string value);
        void Insert(Intent reg);
        void Update(Intent reg);
        void Delete(Intent reg);
        void Remove(Intent reg);
        void SaveChanges();
    }
}
