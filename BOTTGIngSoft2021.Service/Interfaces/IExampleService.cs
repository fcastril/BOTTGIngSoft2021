using BOTTGIngSoft2021.Data.Entities;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Service.Interfaces
{
    public interface IExampleService
    {
        IEnumerable<Example> Get();
        Example Get(long id);
        Example Get(string nameIntent);
        void Insert(Example reg);
        void Delete(long id);
    }
}
