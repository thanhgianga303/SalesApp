
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
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StaffController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDTO>>> GetAll()
        {
            var Staffs = await _unitOfWork.Staff.GetAll();
            var StaffsDTO = _mapper.Map<IEnumerable<Staff>, IEnumerable<StaffDTO>>(Staffs);
            return Ok(StaffsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StaffDTO>>> GetBy(string id)
        {
            var Staff = await _unitOfWork.Staff.GetBy(id);
            var StaffDTO = _mapper.Map<Staff, StaffDTO>(Staff);
            return Ok(StaffDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StaffDTO StaffDTO)
        {
            var Staff = _mapper.Map<StaffDTO, Staff>(StaffDTO);
            await _unitOfWork.Staff.Add(Staff);
            return CreatedAtAction(nameof(GetBy), new { id = Staff.StaffId }, Staff);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, StaffDTO StaffDTO)
        {
            if (StaffDTO.StaffId.ToString() != id)
            {
                return BadRequest();
            }
            try
            {
                var Staff = _mapper.Map<StaffDTO, Staff>(StaffDTO);
                await _unitOfWork.Staff.Update(id, Staff);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StaffExists(id))
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
        private async Task<bool> StaffExists(string id)
        {
            var Staff = await _unitOfWork.Staff.GetBy(id);
            if (Staff != null)
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
            if (await StaffExists(id))
            {
                await _unitOfWork.Staff.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}