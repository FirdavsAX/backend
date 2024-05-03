using backend.Core.Enums;

namespace backend.Core.Dtos.JobDtos
{
    public class JobCreateDto
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        //realtions
        public long CompanyId { get; set; }
    }
}
