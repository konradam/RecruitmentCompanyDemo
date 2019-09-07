using Microsoft.AspNetCore.Mvc;
using RecruitmentCompanyDemo.Models;
using System.Threading.Tasks;

namespace RecruitmentCompanyDemo.Interfaces
{
    public interface IJobOffersService
    {
        int CreateJobCandidate(JobCandidate jobCandidate);
        JobCandidate GetJobCandidateById(int id);
    }
}
