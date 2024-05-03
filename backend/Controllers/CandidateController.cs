using AutoMapper;
using backend.Constants.CandidateConstants;
using backend.Core.Context;
using backend.Core.Dtos.CandidateDtos;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController(ApplicationDbContext context, IMapper mapper) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> Get()
        {
            var candidates = await _context.Candidates.Include(c => c.Job).ToListAsync();
            
            var candidatesDto = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);
            return Ok(candidatesDto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateCandidate([FromForm]CandidateCreateDto candidateCreateDto, IFormFile formFile)
        {
            
            if(formFile?.Length > CandidateCreateConstants.FIVE_MEGABYTE || formFile.ContentType != CandidateCreateConstants.PDF_MIME_TYPE)
            {
                return BadRequest("Bad file is send!");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents" ,"pdfs",resumeUrl);

            using (var stream = new FileStream(filePath,FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            var entity = _mapper.Map<Candidate>(candidateCreateDto);
            entity.ResumeUrl = resumeUrl;

            _context.Candidates.Add(entity);
            await _context.SaveChangesAsync();
            
            return Ok("Good!");
        }

        [HttpGet]
        [Route("download/{url}")]
        public async Task<ActionResult> GetResume(string url)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Documents", "pdfs",url);

            if(!System.IO.File.Exists(filepath))
            {
                return NotFound("File Not Found!");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filepath);
            var file = File(fileBytes,"application/json",url);

            return file;
        }

    }
}
