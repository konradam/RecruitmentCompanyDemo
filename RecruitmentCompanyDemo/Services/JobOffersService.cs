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
        private static int uniqueKey = 0;

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

        public bool UpdateJobCandidate(JobCandidate jobCandidate)
        {
            if (jobCandidates.ContainsKey(jobCandidate.Id))
            {
                jobCandidates[jobCandidate.Id] = jobCandidate;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteJobCandidate(int id)
        {
            if (jobCandidates.ContainsKey(id))
            {
                jobCandidates.Remove(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GenerateId()
        {
            return ++uniqueKey;
        }
    }
}
