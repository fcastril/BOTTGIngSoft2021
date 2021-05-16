using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Repo;
using BOTTGIngSoft2021.Repo.Interfaces;
using BOTTGIngSoft2021.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Service.Services
{
    public class IntentService : IIntentService
    {
        private IRepositoryIntent intentRepository;
        public IntentService(IRepositoryIntent IntentRepository)
        {
            this.intentRepository = IntentRepository;
        }

        public IEnumerable<Intent> Get()
        {
            return intentRepository.GetAll();
        }
        public Intent Get(int id)
        {
            return intentRepository.Get(id);
        }
        public Intent Get(string id)
        {
            return intentRepository.Get(id);
        }
        public Intent GetName(string value)
        {
            return intentRepository.GetName(value);
        }
        public void Insert(Intent Intent)
        {
            intentRepository.Insert(Intent);
        }
        public void Update(Intent Intent)
        {
            intentRepository.Update(Intent);
        }
        public void Delete(int id)
        {
            Intent Intent = Get(id);
            intentRepository.Remove(Intent);
            intentRepository.SaveChanges();
        }

    }
}
