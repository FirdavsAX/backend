﻿using backend.Core.Enums;

namespace backend.Core.Entities
{
    public class Job :BaseEntity
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        
        //realtions
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
        public Job()
        {
            Candidates = new List<Candidate>();
        }
    }
}
