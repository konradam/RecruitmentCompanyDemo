namespace RecruitmentCompanyDemo.Models
{
    public class JobCandidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string ComapnyName { get; set; }
        public bool IsApplicationAccepted { get; set; }
    }
}
