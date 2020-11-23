
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
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAll()
        {
            var accounts = await _unitOfWork.Accounts.GetAll();
            var accountsDTO = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(accounts);
            return Ok(accountsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetBy(int id)
        {
            var account = await _unitOfWork.Accounts.GetBy(id);
            var accountDTO = _mapper.Map<Account, AccountDTO>(account);
            return Ok(accountDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountDTO accountDTO)
        {
            var account = _mapper.Map<AccountDTO, Account>(accountDTO);
            await _unitOfWork.Accounts.Add(account);
            return CreatedAtAction(nameof(GetBy), new { id = account.AccountId }, account);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AccountDTO accountDTO)
        {
            if (accountDTO.AccountId != id)
            {
                return BadRequest();
            }
            try
            {
                var account = _mapper.Map<AccountDTO, Account>(accountDTO);
                await _unitOfWork.Accounts.Update(id, account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AccountExists(id))
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
        private async Task<bool> AccountExists(int id)
        {
            var account = await _unitOfWork.Accounts.GetBy(id);
            if (account != null)
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
            if (await AccountExists(id))
            {
                await _unitOfWork.Accounts.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}