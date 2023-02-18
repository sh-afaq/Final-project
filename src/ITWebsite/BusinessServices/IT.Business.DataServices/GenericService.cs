using AutoMapper;
using IT.Business.Interfaces;
using IT.Data.Interfaces;
using IT.Data.Models;


namespace IT.Business.DataServices
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public GenericService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public List<TModel> GetAll()
        {
            var allEntity=_repository.GetAll();
            var allModels= _mapper.Map<List<TModel>>(allEntity);
            return allModels;
        }
        public void Add(TModel model)
        {
           var entity=_mapper.Map<TEntity>(model);
            _repository.Save(entity);
        }
        public void Update(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _repository.Save(entity);
        }
        public void Delete(int id)
        {
            var entity=_repository.Get(x=>x.Id== id).FirstOrDefault();
            if(entity!=null)
            {
                _repository.Delete(entity);
            }
        }

        

        public List<TModel> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public TModel GetById(int id)
        {
            var entity = _repository.Get(x=>x.Id==id).FirstOrDefault();
            var models = _mapper.Map<TModel>(entity);
            return models;
        }
    }
}
