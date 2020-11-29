
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
    public class ComboController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ComboController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboDTO>>> GetAll()
        {
            var Combos = await _unitOfWork.Combos.GetAll();
            var CombosDTO = _mapper.Map<IEnumerable<Combo>, IEnumerable<ComboDTO>>(Combos);
            return Ok(CombosDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ComboDTO>> GetBy(int id)
        {
            var Combo = await _unitOfWork.Combos.GetBy(id);
            var ComboDTO = _mapper.Map<Combo, ComboDTO>(Combo);
            return Ok(ComboDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ComboDTO ComboDTO)
        {
            var Combo = _mapper.Map<ComboDTO, Combo>(ComboDTO);
            await _unitOfWork.Combos.Add(Combo);
            return CreatedAtAction(nameof(GetBy), new { id = Combo.ComboId }, Combo);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ComboDTO ComboDTO)
        {
            if (ComboDTO.ComboId != id)
            {
                return BadRequest();
            }
            try
            {
                var Combo = _mapper.Map<ComboDTO, Combo>(ComboDTO);
                await _unitOfWork.Combos.Update(id, Combo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ComboExists(id))
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
        private async Task<bool> ComboExists(int id)
        {
            var Combo = await _unitOfWork.Combos.GetBy(id);
            if (Combo != null)
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
            if (await ComboExists(id))
            {
                await _unitOfWork.Combos.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}