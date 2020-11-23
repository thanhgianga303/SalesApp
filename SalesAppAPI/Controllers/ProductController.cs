
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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var Products = await _unitOfWork.Products.GetAll();
            var ProductsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Products);
            return Ok(ProductsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetBy(int id)
        {
            var Product = await _unitOfWork.Products.GetBy(id);
            var ProductDTO = _mapper.Map<Product, ProductDTO>(Product);
            return Ok(ProductDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO ProductDTO)
        {
            var Product = _mapper.Map<ProductDTO, Product>(ProductDTO);
            await _unitOfWork.Products.Add(Product);
            return CreatedAtAction(nameof(GetBy), new { id = Product.ProductId }, Product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDTO ProductDTO)
        {
            if (ProductDTO.ProductId != id)
            {
                return BadRequest();
            }
            try
            {
                var Product = _mapper.Map<ProductDTO, Product>(ProductDTO);
                await _unitOfWork.Products.Update(id, Product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(id))
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
        private async Task<bool> ProductExists(int id)
        {
            var Product = await _unitOfWork.Products.GetBy(id);
            if (Product != null)
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
            if (await ProductExists(id))
            {
                await _unitOfWork.Products.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}