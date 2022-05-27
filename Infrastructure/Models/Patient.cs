using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Models
{
    public class Patient
    {
        public int id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Join(" ", new[] { FirstName, LastName }); } }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }

    public class PatientRequestDto
    {
        public int id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Join(" ", new[] { FirstName, LastName }); } }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }

    public class PatientResponseDto
    {
        public int id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Join(" ", new[] { FirstName, LastName }); } }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
