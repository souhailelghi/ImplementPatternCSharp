using AutoMapper;
using ExampleForAutoMapper.Dto;
using ExampleForAutoMapper.InterfaceUow;
using ExampleForAutoMapper.IRepositorys;
using ExampleForAutoMapper.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleForAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = _unitOfWork.Products.GetAll();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product == null) return NotFound();
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct([FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
            return Ok(productDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _unitOfWork.Products.Update(id, product);
            _unitOfWork.Complete();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            _unitOfWork.Products.Delete(id);
            _unitOfWork.Complete();
            return NoContent();
        }
        //private readonly IBaseRepository<Product> _productRepository;
        //private readonly IMapper _mapper;

        //public ProductController(IBaseRepository<Product> productRepository, IMapper mapper)
        //{
        //    _productRepository = productRepository;
        //    _mapper = mapper;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        //{
        //    var products = _productRepository.GetAll();
        //    var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        //    return Ok(productDtos);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductDto>> GetProductById(int id)
        //{
        //    var product = _productRepository.GetById(id);
        //    if (product == null) return NotFound();
        //    var productDto = _mapper.Map<ProductDto>(product);
        //    return Ok(productDto);
        //}

        //[HttpPost]
        //public async Task<ActionResult<ProductDto>> AddProduct([FromBody] ProductDto productDto)
        //{
        //    var product = _mapper.Map<Product>(productDto);
        //    _productRepository.Add(product);
        //    return Ok(productDto);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        //{
        //    var product = _mapper.Map<Product>(productDto);
        //    _productRepository.Update(id, product);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteProduct(int id)
        //{
        //    _productRepository.Delete(id);
        //    return NoContent();
        //}
    }
}
