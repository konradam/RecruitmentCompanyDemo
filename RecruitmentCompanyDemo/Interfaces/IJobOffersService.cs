using Microsoft.AspNetCore.Mvc;
using RecruitmentCompanyDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentCompanyDemo.Interfaces
{
    public interface IJobOffersService
    {
        int CreateJobCandidate(JobCandidate jobCandidate);
        JobCandidate GetJobCandidateById(int id);
        List<JobCandidate> GetAllJobCandidates();
        bool UpdateJobCandidate(JobCandidate jobCandidate);
    }
}
