using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROGRESSTRACKER.API.Helpers.Mapper.Models;
using PROGRESSTRACKER.API.Helpers.Return;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.SERVICES.DTO.CustomerRequest;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRequestRepository _customerRequestRepository;
        private readonly IAuthRepository _userRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRequestRepository customerRequestRepository, 
            IAuthRepository userRepository, IMapper mapper)
        {
            _customerRequestRepository = customerRequestRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ActionResult GetCustomerRequests()
        {
            
            var request = _customerRequestRepository.GetCustomerRequests(x => x.IsDeleted == false, x => x.User);

            return Ok("Success".SetResponse(200, _mapper.Map<List<CustomerResponse>>(request)));
        }

        public ActionResult GetCustomerRequestsByUserId(CustomerDto dto)
        {
            var user = _userRepository.GetUser(x => x.Id == dto.UserId && x.IsDeleted == false);
            var request = _customerRequestRepository.GetCustomerRequests(x => x.UserId == user.Id && x.IsDeleted == false, x => x.User);
            return Ok("Success".SetResponse(200, _mapper.Map<List<CustomerResponse>>(request)));
        }

        public async Task<ActionResult> CreateCustomerRequest(CustomerDto dto)
        {
            var request = new CustomerRequest
            {
                UserId = dto.UserId,
                Message = dto.Message
            };
            await _customerRequestRepository.AddCustomerRequest(request);
            return Ok("Success".SetResponse(201, new { }));
        }
    }
}
