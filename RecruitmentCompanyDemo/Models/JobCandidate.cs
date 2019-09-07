using System.ComponentModel.DataAnnotations;

namespace RecruitmentCompanyDemo.Models
{
    public class JobCandidate
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string ComapnyName { get; set; }

        public bool IsApplicationAccepted { get; set; }
    }
}
