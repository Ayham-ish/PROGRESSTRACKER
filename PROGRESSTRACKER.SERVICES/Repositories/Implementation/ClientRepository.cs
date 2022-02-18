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
    public class ClientRepository : IClientRepository
    {
        private readonly IRepository<Client> _clientRepository;


        public ClientRepository(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> AddClient(Client entity)
        {
            return await _clientRepository.Insert(entity);
        }


        public async Task DeleteClient(Client entity)
        {
            await _clientRepository.Delete(entity);
        }


        public Client GetClient(Expression<Func<Client, bool>> predicate, params Expression<Func<Client, object>>[] includes)
        {
            return _clientRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<Client> GetClients()
        {
            return _clientRepository.GetAll();
        }

        public List<Client> GetClients(Expression<Func<Client, bool>> predicate, params Expression<Func<Client, object>>[] includes)
        {
            return _clientRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<Client> GetClients(params Expression<Func<Client, object>>[] includes)
        {
            return _clientRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateClient(Client entity)
        {
            await _clientRepository.Update(entity);
        }
    }
}
