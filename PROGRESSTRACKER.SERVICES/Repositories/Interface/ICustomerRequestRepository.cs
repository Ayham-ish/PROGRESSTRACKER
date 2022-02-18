using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.SERVICES.Repositories.Interface
{
    public interface ICustomerRequestRepository
    {

        #region Create
        Task<CustomerRequest> AddCustomerRequest(CustomerRequest entity);

        #endregion



        #region Read
        List<CustomerRequest> GetCustomerRequests();
        List<CustomerRequest> GetCustomerRequests(Expression<Func<CustomerRequest, bool>> predicate, params Expression<Func<CustomerRequest, object>>[] includes);
        List<CustomerRequest> GetCustomerRequests(params Expression<Func<CustomerRequest, object>>[] includes);
        CustomerRequest GetCustomerRequest(Expression<Func<CustomerRequest, bool>> predicate, params Expression<Func<CustomerRequest, object>>[] includes);

        #endregion


        #region Update
        Task UpdateCustomerRequest(CustomerRequest entity);

        #endregion


        #region Delete
        Task DeleteCustomerRequest(CustomerRequest entity);
        #endregion
    }
}
