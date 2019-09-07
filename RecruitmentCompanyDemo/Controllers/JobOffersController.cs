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
        public ActionResult<int> CreateJobCandidate([FromBody] JobCandidate jobCandidate)
        {
            return _jobOffersService.CreateJobCandidate(jobCandidate);
        }

        [HttpGet("{id}")]
        public ActionResult<JobCandidate> GetJobCandidateById(int id)
        {
            return _jobOffersService.GetJobCandidateById(id);
        }

        [HttpGet]
        public ActionResult<List<JobCandidate>> GetAllJobCandidates()
        {
            return _jobOffersService.GetAllJobCandidates();
        }
    }
}
