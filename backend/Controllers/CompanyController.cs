using AutoMapper;
using backend.Core.Context;
using backend.Core.Dtos;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompanyController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] CompanyCreateDto dto)
        {
            Company newCompany = _mapper.Map<Company>(dto);
            _context.Companies.Add(newCompany);
            await _context.SaveChangesAsync();

            return Ok("Succesfully created");
        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> Get()
        {
            var companies = await _context.Companies.ToListAsync();

            var dtos = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);
            return Ok(dtos);
        }

    }
}
