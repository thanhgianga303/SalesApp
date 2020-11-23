
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
    public class CatalogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CatalogController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogDTO>>> GetAll()
        {
            var Catalogs = await _unitOfWork.Catalogs.GetAll();
            var CatalogsDTO = _mapper.Map<IEnumerable<Catalog>, IEnumerable<CatalogDTO>>(Catalogs);
            return Ok(CatalogsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CatalogDTO>>> GetBy(int id)
        {
            var Catalog = await _unitOfWork.Catalogs.GetBy(id);
            var CatalogDTO = _mapper.Map<Catalog, CatalogDTO>(Catalog);
            return Ok(CatalogDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CatalogDTO CatalogDTO)
        {
            var Catalog = _mapper.Map<CatalogDTO, Catalog>(CatalogDTO);
            await _unitOfWork.Catalogs.Add(Catalog);
            return CreatedAtAction(nameof(GetBy), new { id = Catalog.CatalogId }, Catalog);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CatalogDTO CatalogDTO)
        {
            if (CatalogDTO.CatalogId != id)
            {
                return BadRequest();
            }
            try
            {
                var Catalog = _mapper.Map<CatalogDTO, Catalog>(CatalogDTO);
                await _unitOfWork.Catalogs.Update(id, Catalog);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CatalogExists(id))
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
        private async Task<bool> CatalogExists(int id)
        {
            var Catalog = await _unitOfWork.Catalogs.GetBy(id);
            if (Catalog != null)
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
            if (await CatalogExists(id))
            {
                await _unitOfWork.Catalogs.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}