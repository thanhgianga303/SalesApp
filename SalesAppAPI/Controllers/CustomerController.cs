
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesAppAPI.DTOs;
using SalesAppAPI.Models;
using SalesAppAPI.Models.IRepository;

namespace SalesAppAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAll()
        {
            var Customers = await _unitOfWork.Customers.GetAll();
            var CustomersDTO = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(Customers);
            return Ok(CustomersDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetBy(string id)
        {
            var Customer = await _unitOfWork.Customers.GetBy(id);
            var CustomerDTO = _mapper.Map<Customer, CustomerDTO>(Customer);
            return Ok(CustomerDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerDTO CustomerDTO)
        {
            var Customer = _mapper.Map<CustomerDTO, Customer>(CustomerDTO);
            await _unitOfWork.Customers.Add(Customer);
            return CreatedAtAction(nameof(GetBy), new { id = Customer.CustomerId }, Customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CustomerDTO CustomerDTO)
        {
            if (CustomerDTO.CustomerId.ToString() != id)
            {
                return BadRequest();
            }
            try
            {
                var Customer = _mapper.Map<CustomerDTO, Customer>(CustomerDTO);
                await _unitOfWork.Customers.Update(id, Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return NoContent();
        }
        private async Task<bool> CustomerExists(string id)
        {
            var Customer = await _unitOfWork.Customers.GetBy(id);
            if (Customer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await CustomerExists(id))
            {
                await _unitOfWork.Customers.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}