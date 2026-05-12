namespace ApiVerse.Api.Models.JobModes
{
    public class ResultJobModel
    {
        public string Status { get; set; }
        public JobData Data { get; set; }

        public class JobData
        {
            public List<JobResult> Jobs { get; set; }
        }

        public class JobResult
        {
            public string Job_Id { get; set; }
            public string Job_Title { get; set; }
            public string Employer_Name { get; set; }
            public string Employer_Logo { get; set; }
            public string Employer_Website { get; set; }
            public string Job_Publisher { get; set; }
            public string Job_Employment_Type { get; set; }
            public string Job_Apply_Link { get; set; }
            public string Job_Description { get; set; }
            public bool Job_Is_Remote { get; set; }
            public string Job_Posted_At { get; set; }
            public string Job_Location { get; set; }
            public string Job_City { get; set; }
            public string Job_Country { get; set; }
            public string Job_Salary_String { get; set; }
            public decimal? Job_Min_Salary { get; set; }
            public decimal? Job_Max_Salary { get; set; }
            public string Job_Salary_Period { get; set; }
            public List<string> Job_Benefits_Strings { get; set; }
        }
    }
}
