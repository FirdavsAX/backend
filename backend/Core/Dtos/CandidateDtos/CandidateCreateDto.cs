namespace backend.Core.Dtos.CandidateDtos
{
    public class CandidateCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ConvertLetter { get; set; }
        public long JobId { get; set; }
    }
}
