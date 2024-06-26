﻿namespace backend.Core.Entities
{
    public class Candidate : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ConvertLetter { get; set; }
        public string ResumeUrl { get; set; }
        //relations
        public long JobId{ get; set; }
        public Job Job { get; set; }
    }
}
