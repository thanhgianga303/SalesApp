
using System.Collections.Generic;
using System.Linq;
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
    public class ComboDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ComboDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, List<ComboDetailsDTO> newListComboDetailsDTO)
        {
            var listComboDetails = _mapper.Map<IEnumerable<ComboDetailsDTO>, IEnumerable<ComboDetails>>(newListComboDetailsDTO);
            await _unitOfWork.Combos.UpdateComboDetails(id, listComboDetails.ToList());
            return Ok(listComboDetails);
        }
    }
}