using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitmentCompanyDemo.Interfaces;
using RecruitmentCompanyDemo.Models;

namespace RecruitmentCompanyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOffersController : ControllerBase
    {
        private readonly IJobOffersService _jobOffersService;

        public JobOffersController(IJobOffersService jobOffersService)
        {
            _jobOffersService = jobOffersService;
        }

        [HttpPost]
        public ActionResult<JobCandidate> CreateJobCandidate([FromBody] JobCandidate jobCandidate)
        {
            return _jobOffersService.CreateJobCandidate(jobCandidate);
        }

        [HttpGet("{id}")]
        public ActionResult<JobCandidate> GetJobCandidateById(int id)
        {
            return _jobOffersService.GetJobCandidateById(id);
        }

        [HttpGet]
        public ActionResult<List<JobCandidate>> GetJobCandidates([FromQuery]string firstName, [FromQuery]string lastName, [FromQuery]string jobTitle, [FromQuery]string companyName)
        {
            return _jobOffersService.GetJobCandidates(firstName, lastName, jobTitle, companyName);
        }

        [HttpPut]
        public ActionResult<bool> UpdateJobCandidate([FromBody] JobCandidate jobCandidate)
        {
            return _jobOffersService.UpdateJobCandidate(jobCandidate);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteJobCandidate(int id)
        {
            return _jobOffersService.DeleteJobCandidate(id);
        }
    }
}
