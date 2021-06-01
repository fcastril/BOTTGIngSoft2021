using BOTTGIngSoft2021.Data.Entities;
using System;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Service.Interfaces
{
    public interface IIntentService
    {
        IEnumerable<Intent> Get();
        Intent Get(int id);
        Intent Get(string id);
        Intent GetName(string value);
        void Insert(Intent reg);
        void Update(Intent reg);
        void Delete(int id);
    }
}
