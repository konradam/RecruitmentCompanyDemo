using Microsoft.AspNetCore.Mvc;
using RecruitmentCompanyDemo.Interfaces;
using RecruitmentCompanyDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentCompanyDemo.Services
{
    public class JobOffersService : IJobOffersService
    {
        private static Dictionary<int, JobCandidate> jobCandidates = new Dictionary<int, JobCandidate>();

        public int CreateJobCandidate(JobCandidate jobCandidate)
        {
            jobCandidate.Id = GenerateId();
            jobCandidates.Add(jobCandidate.Id, jobCandidate);
            return jobCandidate.Id;
        }

        public JobCandidate GetJobCandidateById(int id)
        {
            if (jobCandidates.ContainsKey(id))
                return jobCandidates[id];
            else
                return null;
        }

        public List<JobCandidate> GetAllJobCandidates()
        {
            return jobCandidates.Select(x => x.Value).ToList();
        }

        private int GenerateId()
        {
            return jobCandidates.Keys.Count + 1;
        }
    }
}
