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
        private IDictionary<int, JobCandidate> _jobCandidates;
        private static int uniqueKey = 0;

        public JobOffersService(IDictionary<int, JobCandidate> jobCandidates)
        {
            _jobCandidates = jobCandidates;
        }

        public JobCandidate CreateJobCandidate(JobCandidate jobCandidate)
        {
            jobCandidate.Id = GenerateId();
            _jobCandidates.Add(jobCandidate.Id, jobCandidate);
            return jobCandidate;
        }

        public JobCandidate GetJobCandidateById(int id)
        {
            if (_jobCandidates.ContainsKey(id))
            {
                JobCandidate jobCandidate;
                _jobCandidates.TryGetValue(id, out jobCandidate);
                return jobCandidate;
            }
            else
            {
                return null;
            }
        }

        public List<JobCandidate> GetJobCandidates(string firstName, string lastName, string jobTitle, string companyName)
        {
            return _jobCandidates.Select(x => x.Value)
                .Where(y => string.IsNullOrWhiteSpace(firstName) || y.FirstName == firstName)
                .Where(y => string.IsNullOrWhiteSpace(lastName) || y.LastName == lastName)
                .Where(y => string.IsNullOrWhiteSpace(jobTitle) || y.JobTitle == jobTitle)
                .Where(y => string.IsNullOrWhiteSpace(companyName) || y.ComapnyName == companyName)
                .ToList();
        }

        public bool UpdateJobCandidate(JobCandidate jobCandidate)
        {
            if (_jobCandidates.ContainsKey(jobCandidate.Id))
            {
                _jobCandidates[jobCandidate.Id] = jobCandidate;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteJobCandidate(int id)
        {
            if (_jobCandidates.ContainsKey(id))
            {
                _jobCandidates.Remove(id);
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
