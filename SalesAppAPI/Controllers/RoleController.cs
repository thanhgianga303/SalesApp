
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesAppAPI.DTOs;
using SalesAppAPI.Models;
using SalesAppAPI.Models.IRepository;

namespace SalesAppAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAll()
        {
            var roles = await _unitOfWork.Roles.GetAll();
            var rolesDTO = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(roles);
            return Ok(rolesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetBy(int id)
        {
            var role = await _unitOfWork.Roles.GetBy(id);
            var roleDTO = _mapper.Map<Role, RoleDTO>(role);
            return Ok(roleDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleDTO roleDTO)
        {
            var role = _mapper.Map<RoleDTO, Role>(roleDTO);
            await _unitOfWork.Roles.Add(role);
            await _unitOfWork.Complete();
            return CreatedAtAction(nameof(GetBy), new { id = role.RoleId }, role);
        }
    }
}