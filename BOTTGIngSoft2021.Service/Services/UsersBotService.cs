using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Repo.Interfaces;
using BOTTGIngSoft2021.Service.Interfaces;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Service.Services
{
    public class UsersBotService: IUsersBotService
    {
        private IRepository<UsersBot> UsersBotRepository;
        public UsersBotService(IRepository<UsersBot> UsersBotRepository)
        {
            this.UsersBotRepository = UsersBotRepository;

        }

        public IEnumerable<UsersBot> Get()
        {
            return UsersBotRepository.GetAll();
        }
        public UsersBot Get(int id)
        {
            return UsersBotRepository.Get(id);
        }
        public UsersBot Get(string id)
        {
            return UsersBotRepository.Get(id);
        }
        public IEnumerable<UsersBot> Get(string field, string value)
        {
            return UsersBotRepository.Get(field, value);
        }
        public void Insert(UsersBot UsersBot)
        {
            UsersBotRepository.Insert(UsersBot);
        }
        public void Update(UsersBot UsersBot)
        {
            UsersBotRepository.Update(UsersBot);
        }
        public void Delete(int id)
        {
            UsersBot UsersBot = Get(id);
            UsersBotRepository.Remove(UsersBot);
            UsersBotRepository.SaveChanges();
        }
    }
}
