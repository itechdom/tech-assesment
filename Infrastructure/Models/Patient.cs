using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace justice_technical_assestment.Infrastructure.Models
{
    public class Patient
    {
        public int Id;
        public Doctor? Doctor { get; set; }
        public int DoctorId { get; set; }
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
        public Doctor? Doctor { get; set; }
        public Kin? Kin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Join(" ", new[] { FirstName, LastName }); } }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
    }

    public class PatientUpdateRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Join(" ", new[] { FirstName, LastName }); } }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int DoctorId;
        public int KinId;
    }
}
