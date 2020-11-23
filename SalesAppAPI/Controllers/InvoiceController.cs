
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
    public class InvoiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public InvoiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAll()
        {
            var Invoices = await _unitOfWork.Invoices.GetAll();
            var InvoicesDTO = _mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceDTO>>(Invoices);
            return Ok(InvoicesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetBy(int id)
        {
            var Invoice = await _unitOfWork.Invoices.GetBy(id);
            var InvoiceDTO = _mapper.Map<Invoice, InvoiceDTO>(Invoice);
            return Ok(InvoiceDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(InvoiceDTO InvoiceDTO)
        {
            var Invoice = _mapper.Map<InvoiceDTO, Invoice>(InvoiceDTO);
            await _unitOfWork.Invoices.Add(Invoice);
            return CreatedAtAction(nameof(GetBy), new { id = Invoice.InvoiceId }, Invoice);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InvoiceDTO InvoiceDTO)
        {
            if (InvoiceDTO.InvoiceId != id)
            {
                return BadRequest();
            }
            try
            {
                var Invoice = _mapper.Map<InvoiceDTO, Invoice>(InvoiceDTO);
                await _unitOfWork.Invoices.Update(id, Invoice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await InvoiceExists(id))
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
        private async Task<bool> InvoiceExists(int id)
        {
            var Invoice = await _unitOfWork.Invoices.GetBy(id);
            if (Invoice != null)
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
            if (await InvoiceExists(id))
            {
                await _unitOfWork.Invoices.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}