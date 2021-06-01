using BOTTGIngSoft2021.Data.Entities;
using BOTTGIngSoft2021.Repo.Interfaces;
using BOTTGIngSoft2021.Service.Interfaces;
using System.Collections.Generic;

namespace BOTTGIngSoft2021.Service.Services
{
    public class ExampleService : IExampleService
    {
        private IRepositoryExample ExampleRepository;
        public ExampleService(IRepositoryExample ExampleRepository)
        {
            this.ExampleRepository = ExampleRepository;
        }

        public IEnumerable<Example> Get()
        {
            return ExampleRepository.GetAll();
        }
        public Example Get(long id)
        {
            return ExampleRepository.Get(id);
        }
        public Example Get(string nameIntent)
        {
            return ExampleRepository.Get(nameIntent);
        }
        public void Insert(Example Example)
        {
            ExampleRepository.Insert(Example);
        }
        public void Delete(long id)
        {
            Example Example = Get(id);
            ExampleRepository.Remove(Example);
            ExampleRepository.SaveChanges();
        }


    }
}
