using AutoMapper;
using backend.Core.AutoMapperConfig;
using backend.Core.Context;
using backend.Core.Dtos.JobDtos;
using backend.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public JobController(IMapper mapper,ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> Get()
        {
            var jobs = await _context.Jobs.Include(x => x.Company).Include(c => c.Candidates).ToListAsync();

            var dtos = _mapper.Map<IEnumerable<JobGetDto>>(jobs);
            return Ok(dtos);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult>Create([FromBody]JobCreateDto jobCreateDto)
        {
            var entity = _mapper.Map<Job>(jobCreateDto);

            _context.Jobs.Add(entity);
            await _context.SaveChangesAsync();

            return Ok("Job Created Succesfully");  
        }
    }
}
