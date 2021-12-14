using System;

namespace PracticeManagement.Core.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public string PracticeRemarks { get; set; }
        public string Diagnosis { get; set; }
        public string SecondDiagnosis { get; set; }
        public string ThirdDiagnosis { get; set; }
        public string Therapy { get; set; }
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }

}