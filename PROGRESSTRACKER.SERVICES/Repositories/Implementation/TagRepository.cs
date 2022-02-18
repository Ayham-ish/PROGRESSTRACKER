using PROGRESSTRACKER.DAL.Interface;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Implementation
{
    public class TagRepository : ITagRepository
    {
        private readonly IRepository<Tag> _tagRepository;



        public TagRepository(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Tag> AddTag(Tag entity)
        {
            return await _tagRepository.Insert(entity);
        }


        public async Task DeleteTag(Tag entity)
        {
            await _tagRepository.Delete(entity);
        }


        public Tag GetTag(Expression<Func<Tag, bool>> predicate, params Expression<Func<Tag, object>>[] includes)
        {
            return _tagRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<Tag> GetTags()
        {
            return _tagRepository.GetAll();
        }

        public List<Tag> GetTags(Expression<Func<Tag, bool>> predicate, params Expression<Func<Tag, object>>[] includes)
        {
            return _tagRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<Tag> GetTags(params Expression<Func<Tag, object>>[] includes)
        {
            return _tagRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateTag(Tag entity)
        {
            await _tagRepository.Update(entity);
        }
    }
}
