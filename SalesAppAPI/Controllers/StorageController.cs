
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
    public class StorageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StorageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageDTO>>> GetAll()
        {
            var Storages = await _unitOfWork.Storage.GetAll();
            var StoragesDTO = _mapper.Map<IEnumerable<Storage>, IEnumerable<StorageDTO>>(Storages);
            return Ok(StoragesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StorageDTO>>> GetBy(string id)
        {
            var Storage = await _unitOfWork.Storage.GetBy(id);
            var StorageDTO = _mapper.Map<Storage, StorageDTO>(Storage);
            return Ok(StorageDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StorageDTO StorageDTO)
        {
            var Storage = _mapper.Map<StorageDTO, Storage>(StorageDTO);
            await _unitOfWork.Storage.Add(Storage);
            return CreatedAtAction(nameof(GetBy), new { id = Storage.StorageId }, Storage);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, StorageDTO StorageDTO)
        {
            if (StorageDTO.StorageId.ToString() != id)
            {
                return BadRequest();
            }
            try
            {
                var Storage = _mapper.Map<StorageDTO, Storage>(StorageDTO);
                await _unitOfWork.Storage.Update(id, Storage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StorageExists(id))
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
        private async Task<bool> StorageExists(string id)
        {
            var Storage = await _unitOfWork.Storage.GetBy(id);
            if (Storage != null)
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
            if (await StorageExists(id))
            {
                await _unitOfWork.Storage.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}