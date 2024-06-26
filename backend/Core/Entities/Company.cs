﻿
using backend.Core.Enums;

namespace backend.Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public CompanySize  Size { get; set; }
        //relations
        public ICollection<Job> Job { get; set; }
        public Company() 
        {
            Job = new List<Job>();
        }

    }
}
