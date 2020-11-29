
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
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetailsDTO>> GetBy(int id)
        {
            var InvoiceDetails = await _unitOfWork.Invoices.GetByInvoiceDetails(id);
            var InvoiceDTO = _mapper.Map<InvoiceDetails, InvoiceDetailsDTO>(InvoiceDetails);
            return Ok(InvoiceDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Create(InvoiceDetailsDTO InvoiceDetailsDTO)
        {
            var InvoiceDetails = _mapper.Map<InvoiceDetailsDTO, InvoiceDetails>(InvoiceDetailsDTO);
            await _unitOfWork.Invoices.AddInvoiceDetails(InvoiceDetails);
            return CreatedAtAction(nameof(GetBy), new { id = InvoiceDetails.InvoiceDetailsId }, InvoiceDetails);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InvoiceDetailsDTO InvoiceDetailsDTO)
        {
            if (InvoiceDetailsDTO.InvoiceDetailsId != id)
            {
                return BadRequest();
            }
            try
            {
                var InvoiceDetails = _mapper.Map<InvoiceDetailsDTO, InvoiceDetails>(InvoiceDetailsDTO);
                await _unitOfWork.Invoices.UpdateInvoiceDetails(InvoiceDetails);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await InvoiceDetailsExists(id))
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
        private async Task<bool> InvoiceDetailsExists(int id)
        {
            var InvoiceDetails = await _unitOfWork.Invoices.GetByInvoiceDetails(id);
            if (InvoiceDetails != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await InvoiceDetailsExists(id))
            {
                await _unitOfWork.Invoices.DeleteInvoiceDetails(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}