using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Repo.Interfaces;
using BOTTGIngSoft2021.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Service.Services
{
    public class IntentService : IIntentService
    {
        private IRepository<Intent> intentRepository;
        public IntentService(IRepository<Intent> IntentRepository)
        {
            this.intentRepository = IntentRepository;

        }

        public IEnumerable<Intent> GetIntents()
        {
            return intentRepository.GetAll();
        }
        public Intent GetIntent(Guid id)
        {
            return intentRepository.Get(id);
        }
        public void InsertIntent(Intent Intent)
        {
            intentRepository.Insert(Intent);
        }
        public void UpdateIntent(Intent Intent)
        {
            intentRepository.Update(Intent);
        }
        public void DeleteIntent(Guid id)
        {
            Intent Intent = GetIntent(id);
            intentRepository.Remove(Intent);
            intentRepository.SaveChanges();
        }

    }
}
