
using AutoMapper;
using IT.Business.Interfaces;
using IT.Business.Models;
using IT.Data;
using IT.Data.Interfaces;
using IT.Data.Models;

namespace IT.Business.DataServices
{
    public class BlogService: GenericService<BlogModel,Blog>,IBlogService
    {
        private readonly IRepository<Blog> _repository;
       
        public BlogService(IRepository<Blog>  repository,IMapper mapper):base (repository,mapper)
        {
            _repository=repository;
        }    
        public List<BlogModel> Search(string searchTerm)
        {
            searchTerm = searchTerm.Trim().ToLower();
            var allblogs = _repository.Get(x => x.Name.ToLower()
                .Contains(searchTerm) ).ToList();
            var blogModels = allblogs.Select(x => new BlogModel
            {
                
                Name = x.Name,
                Description = x.Description
            }).ToList();
            return blogModels;
        }
       

        
    }
}