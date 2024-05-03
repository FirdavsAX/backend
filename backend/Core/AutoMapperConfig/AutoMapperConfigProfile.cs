using AutoMapper;
using backend.Core.Dtos;
using backend.Core.Dtos.CandidateDtos;
using backend.Core.Dtos.JobDtos;
using backend.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile:Profile
    {
        public AutoMapperConfigProfile()
        {
            //Company
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();

            //Job
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName , opt => opt.MapFrom(src => src.Company.Name));

            //Candidate
            CreateMap<CandidateCreateDto, Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title));
        }
    }
}
