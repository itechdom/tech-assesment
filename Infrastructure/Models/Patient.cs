using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Models
{
    public class Patient
    {
        public int Id;
        public Doctor? Doctor { get; set; }
        public Kin? Kin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Join(" ", new[] { FirstName, LastName }); } }
        public string PassNo { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderCode Gender { get; set; }
    }
    public enum GenderCode
    {
        M,
        F
    }

    public class PatientRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Join(" ", new[] { FirstName, LastName }); } }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }

    public class PatientResponseDto
    {
        public List<PatientResponse> patients { get; set; }
    }

    public class PatientResponse
    {
        public Patient? patient { get; set; }
        public Doctor? doctor { get; set; }
        public Kin? kin { get; set; }
    }
}
