﻿
namespace IT.Business.Interfaces
{
    public interface IGenericService<TModel>
    {

        public List<TModel> GetAll();
        public TModel GetById(int id);
        public List<TModel> Search(string searchTerm);
        public void Add(TModel model);
        public void Update(TModel model);
        public void Delete(int id);

    }
}
