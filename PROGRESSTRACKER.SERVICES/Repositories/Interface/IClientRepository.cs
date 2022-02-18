using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface IClientRepository
    {
        #region Create
        Task<Client> AddClient(Client entity);

        #endregion



        #region Read
        List<Client> GetClients();
        List<Client> GetClients(Expression<Func<Client, bool>> predicate, params Expression<Func<Client, object>>[] includes);
        List<Client> GetClients(params Expression<Func<Client, object>>[] includes);
        Client GetClient(Expression<Func<Client, bool>> predicate, params Expression<Func<Client, object>>[] includes);

        #endregion


        #region Update
        Task UpdateClient(Client entity);

        #endregion


        #region Delete
        Task DeleteClient(Client entity);
        #endregion
    }
}