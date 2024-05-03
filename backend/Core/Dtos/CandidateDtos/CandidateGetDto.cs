using backend.Core.Entities;
using backend.Core.Enums;

namespace backend.Core.Dtos.CandidateDtos
{
    public class CandidateGetDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ConvertLetter { get; set; }
        public string ResumeUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long JobId { get; set; }
        public string JobTitle { get; set; }
    }
}
