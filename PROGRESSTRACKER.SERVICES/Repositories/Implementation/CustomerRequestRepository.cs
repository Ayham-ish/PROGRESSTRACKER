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
    public class CustomerRequestRepository : ICustomerRequestRepository
    {
        private readonly IRepository<CustomerRequest> _customerRequestRepository;


        public CustomerRequestRepository(IRepository<CustomerRequest> customerRequestRepository)
        {
            _customerRequestRepository = customerRequestRepository;
        }

        public async Task<CustomerRequest> AddCustomerRequest(CustomerRequest entity)
        {
            return await _customerRequestRepository.Insert(entity);
        }


        public async Task DeleteCustomerRequest(CustomerRequest entity)
        {
            await _customerRequestRepository.Delete(entity);
        }


        public CustomerRequest GetCustomerRequest(Expression<Func<CustomerRequest, bool>> predicate, params Expression<Func<CustomerRequest, object>>[] includes)
        {
            return _customerRequestRepository.FindByConditionWithIncludes(predicate, includes);
        }

        public List<CustomerRequest> GetCustomerRequests()
        {
            return _customerRequestRepository.GetAll();
        }

        public List<CustomerRequest> GetCustomerRequests(Expression<Func<CustomerRequest, bool>> predicate, params Expression<Func<CustomerRequest, object>>[] includes)
        {
            return _customerRequestRepository.FindAllByConditionWithIncludes(predicate, includes).ToList();
        }

        public List<CustomerRequest> GetCustomerRequests(params Expression<Func<CustomerRequest, object>>[] includes)
        {
            return _customerRequestRepository.FindAllWithIncludes(includes).ToList();
        }

        public async Task UpdateCustomerRequest(CustomerRequest entity)
        {
            await _customerRequestRepository.Update(entity);
        }
    }
}
