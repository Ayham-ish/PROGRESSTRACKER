using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface ITagRepository
    {
        #region Create
        Task<Tag> AddTag(Tag entity);

        #endregion



        #region Read
        List<Tag> GetTags();
        List<Tag> GetTags(Expression<Func<Tag, bool>> predicate, params Expression<Func<Tag, object>>[] includes);
        List<Tag> GetTags(params Expression<Func<Tag, object>>[] includes);
        Tag GetTag(Expression<Func<Tag, bool>> predicate, params Expression<Func<Tag, object>>[] includes);

        #endregion


        #region Update
        Task UpdateTag(Tag entity);

        #endregion


        #region Delete
        Task DeleteTag(Tag entity);
        #endregion
    }
}
