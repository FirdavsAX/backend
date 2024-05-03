﻿using backend.Core.Enums;

namespace backend.Core.Dtos.JobDtos
{
    public class JobGetDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public long CompanyId { get; set; }
        public string CompanyName { get; set;}
    }
}
