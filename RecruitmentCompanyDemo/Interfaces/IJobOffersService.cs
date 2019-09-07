using Microsoft.AspNetCore.Mvc;
using RecruitmentCompanyDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentCompanyDemo.Interfaces
{
    public interface IJobOffersService
    {
        JobCandidate CreateJobCandidate(JobCandidate jobCandidate);
        JobCandidate GetJobCandidateById(int id);
        List<JobCandidate> GetJobCandidates(string firstName, string lastName, string jobTitle, string companyName);
        bool UpdateJobCandidate(JobCandidate jobCandidate);
        bool DeleteJobCandidate(int id);
    }
}
