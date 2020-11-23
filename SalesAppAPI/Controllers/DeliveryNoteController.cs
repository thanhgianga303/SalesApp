
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
    public class DeliveryNoteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeliveryNoteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryNoteDTO>>> GetAll()
        {
            var DeliveryNotes = await _unitOfWork.DeliveryNotes.GetAll();
            var DeliveryNotesDTO = _mapper.Map<IEnumerable<DeliveryNote>, IEnumerable<DeliveryNoteDTO>>(DeliveryNotes);
            return Ok(DeliveryNotesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DeliveryNoteDTO>>> GetBy(string id)
        {
            var DeliveryNote = await _unitOfWork.DeliveryNotes.GetBy(id);
            var DeliveryNoteDTO = _mapper.Map<DeliveryNote, DeliveryNoteDTO>(DeliveryNote);
            return Ok(DeliveryNoteDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DeliveryNoteDTO DeliveryNoteDTO)
        {
            var DeliveryNote = _mapper.Map<DeliveryNoteDTO, DeliveryNote>(DeliveryNoteDTO);
            await _unitOfWork.DeliveryNotes.Add(DeliveryNote);
            return CreatedAtAction(nameof(GetBy), new { id = DeliveryNote.DeliveryNoteId }, DeliveryNote);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, DeliveryNoteDTO DeliveryNoteDTO)
        {
            if (DeliveryNoteDTO.DeliveryNoteId.ToString() != id)
            {
                return BadRequest();
            }
            try
            {
                var DeliveryNote = _mapper.Map<DeliveryNoteDTO, DeliveryNote>(DeliveryNoteDTO);
                await _unitOfWork.DeliveryNotes.Update(id, DeliveryNote);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DeliveryNoteExists(id))
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
        private async Task<bool> DeliveryNoteExists(string id)
        {
            var DeliveryNote = await _unitOfWork.DeliveryNotes.GetBy(id);
            if (DeliveryNote != null)
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
            if (await DeliveryNoteExists(id))
            {
                await _unitOfWork.DeliveryNotes.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}