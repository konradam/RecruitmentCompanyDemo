using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecruitmentCompanyDemo.Models;
using RecruitmentCompanyDemo.Services;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentCompanyDemoTests.Services
{
    [TestClass]
    public class JobOffersServiceTest
    {
        private JobCandidate _jobCandidate;

        [TestInitialize]
        public void SetUpJobCandidate()
        {
            _jobCandidate = new JobCandidate
            {
                FirstName = "John",
                LastName = "Smith",
                JobTitle = "Developer",
                ComapnyName = "Equiniti",
                IsApplicationAccepted = true
            };
        }

        [TestMethod]
        public void CreateJobCandidate_CreateNewJobCandidate_ReturnsCreatedJobCandidate()
        {
            //arrange
            var jobCandidatesMock = new Mock<IDictionary<int, JobCandidate>>();
            var jobOffersService = new JobOffersService(jobCandidatesMock.Object);

            //act 
            var actual = jobOffersService.CreateJobCandidate(_jobCandidate);

            //assert
            Assert.AreEqual(actual.Id, 1);
            Assert.AreEqual(actual.FirstName, _jobCandidate.FirstName);
            Assert.AreEqual(actual.LastName, _jobCandidate.LastName);
            Assert.AreEqual(actual.JobTitle, _jobCandidate.JobTitle);
            Assert.AreEqual(actual.ComapnyName, _jobCandidate.ComapnyName);
            Assert.AreEqual(actual.IsApplicationAccepted, _jobCandidate.IsApplicationAccepted);
        }

        [TestMethod]
        public void GetJobCandidateById_InvalidId_ReturnsNull()
        {
            //arrange
            var jobCandidatesMock = new Mock<IDictionary<int, JobCandidate>>();
            var jobOffersService = new JobOffersService(jobCandidatesMock.Object);

            //act 
            var actual = jobOffersService.GetJobCandidateById(0);

            //assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetJobCandidateById_ValidId_ReturnsJobCandidate()
        {
            //arrange
            var jobCandidatesMock = new Mock<IDictionary<int, JobCandidate>>();
            jobCandidatesMock.Setup(x => x.ContainsKey(It.IsAny<int>())).Returns(true);
            jobCandidatesMock.Setup(x => x.TryGetValue(It.IsAny<int>(), out _jobCandidate));
            var jobOffersService = new JobOffersService(jobCandidatesMock.Object);

            //act 
            var actual = jobOffersService.GetJobCandidateById(1);

            //assert
            Assert.AreEqual(actual.FirstName, _jobCandidate.FirstName);
            Assert.AreEqual(actual.LastName, _jobCandidate.LastName);
            Assert.AreEqual(actual.JobTitle, _jobCandidate.JobTitle);
            Assert.AreEqual(actual.ComapnyName, _jobCandidate.ComapnyName);
            Assert.AreEqual(actual.IsApplicationAccepted, _jobCandidate.IsApplicationAccepted);
        }

        [TestMethod]
        public void UpdateJobCandidate_InvalidId_ReturnsFalse()
        {
            //arrange
            var jobCandidatesMock = new Mock<IDictionary<int, JobCandidate>>();
            jobCandidatesMock.Setup(x => x.ContainsKey(It.IsAny<int>())).Returns(false);
            var jobOffersService = new JobOffersService(jobCandidatesMock.Object);

            //act 
            var actual = jobOffersService.UpdateJobCandidate(_jobCandidate);

            //assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void UpdateJobCandidate_ValidId_ReturnsTrue()
        {
            //arrange
            var jobCandidatesMock = new Mock<IDictionary<int, JobCandidate>>();
            jobCandidatesMock.Setup(x => x.ContainsKey(It.IsAny<int>())).Returns(true);
            var jobOffersService = new JobOffersService(jobCandidatesMock.Object);
            _jobCandidate.Id = 1;

            //act 
            var actual = jobOffersService.UpdateJobCandidate(_jobCandidate);

            //assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeleteJobCandidate_InvalidId_ReturnsFalse()
        {
            //arrange
            var jobCandidatesMock = new Mock<IDictionary<int, JobCandidate>>();
            jobCandidatesMock.Setup(x => x.ContainsKey(It.IsAny<int>())).Returns(false);
            var jobOffersService = new JobOffersService(jobCandidatesMock.Object);

            //act 
            var actual = jobOffersService.DeleteJobCandidate(It.IsAny<int>());

            //assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void DeleteJobCandidate_ValidId_ReturnsTrue()
        {
            //arrange
            var jobCandidatesMock = new Mock<IDictionary<int, JobCandidate>>();
            jobCandidatesMock.Setup(x => x.ContainsKey(It.IsAny<int>())).Returns(true);
            var jobOffersService = new JobOffersService(jobCandidatesMock.Object);
            _jobCandidate.Id = 1;

            //act 
            var actual = jobOffersService.DeleteJobCandidate(_jobCandidate.Id);

            //assert
            Assert.IsTrue(actual);
        }
    }
}
