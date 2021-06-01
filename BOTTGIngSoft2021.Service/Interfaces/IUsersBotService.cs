using BOTTGIngSoft2021.Data.Entities;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Service.Interfaces
{
    public interface IUsersBotService
    {
        IEnumerable<UsersBot> Get();
        UsersBot Get(int id);
        UsersBot Get(string id);

        IEnumerable<UsersBot> Get(string field, string value);
        void Insert(UsersBot reg);
        void Update(UsersBot reg);
        void Delete(int id);
    }
}
