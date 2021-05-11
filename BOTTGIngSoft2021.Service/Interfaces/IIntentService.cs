using BOTTGIngSoft2021.Data.Entities;
using System;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Service.Interfaces
{
    public interface IIntentService
    {
        IEnumerable<Intent> GetIntents();
        Intent GetIntent(Guid id);
        void InsertIntent(Intent reg);
        void UpdateIntent(Intent reg);
        void DeleteIntent(Guid id);
    }
}
