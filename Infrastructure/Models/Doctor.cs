namespace justice_technical_assestment.Infrastructure.Models
{
    public class Doctor
    {
        public int DoctorId;
        public int Code;
        public string Surname { get; set; }
        public string Initialis { get; set; }
        public string MobileNumber { get; set; }
    }
}