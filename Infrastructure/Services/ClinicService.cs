using justice_technical_assestment.Infrastructure.Models;
using justice_technical_assestment.Models;
using justice_technical_assestment.Infrastructure.Repositories;


namespace justice_technical_assestment.Infrastructure.Services
{
    public class ClinicService
    {
        private readonly IHttpContextAccessor _context;
        public IdentityService _IdentityService { get; }
        public PatientRepository _PatientRepository { get; set; }

        public DoctorRepository _DoctorRepository { get; set; }

        public KinRepository _KinRepository { get; set; }
        public string _AppBaseUrl => $"{_context.HttpContext.Request.Scheme}://{_context.HttpContext.Request.Host}{_context.HttpContext.Request.PathBase}";

        public string _headerLanguage => _context.HttpContext.Request.Headers["accept-language"].ToString() ?? "ar";

        private readonly IConfiguration _Configuration;

        public ClinicService(
            IdentityService identityService,
            PatientRepository patientRepository,
            DoctorRepository doctorRepository,
            KinRepository kinRepository,
            IHttpContextAccessor context,
            IConfiguration configuration
            )
        {
            _IdentityService = identityService;
            _PatientRepository = patientRepository;
            _KinRepository = kinRepository;
            _DoctorRepository = doctorRepository;
            _context = context;
            _Configuration = configuration;
        }

        public async Task<List<Patient>> GetPatients(int? patientId)
        {
            var dbPatients = await _PatientRepository.Get(0, 10);
            return dbPatients;
        }
        public async Task<List<Doctor>> GetDoctors(int? doctorId)
        {
            var dbDoctors = await _DoctorRepository.Get(0, 10);
            return dbDoctors;
        }
        public async Task<List<Kin>> GetKins(int? patientId)
        {
            var dbKins = await _KinRepository.Get(0, 10);
            return dbKins;
        }
        public async Task<long> CreateKin(KinRequestDto kin)
        {
            var newKin = new Kin
            {
                FirstName = kin.FirstName,
                LastName = kin.LastName,
                AddressLineOne = kin.AddressLineOne,
                AddressLineTwo = kin.AddressLineTwo,
                AddressLineThree = kin.AddressLineThree,
                AddressLineFour = kin.AddressLineFour,
                PostalCode = kin.PostalCode,
                Relation = kin.Relation
            };
            _KinRepository.Add(newKin);
            await _KinRepository.SaveChanges();
            return newKin.Id;
        }
        public async Task<long> CreatePatient(PatientRequestDto patient)
        {
            var newPatient = new Patient
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                MobileNumber = patient.MobileNumber,
                PassNo = "Test",
                DateOfBirth = new DateTime(),
                Gender = GenderCode.M
            };
            var newKin = new Kin
            {
                FirstName = patient.Kin?.FirstName,
                LastName = patient.Kin?.LastName
            };
            newPatient.Kin = newKin;
            _PatientRepository.Add(newPatient);
            await _PatientRepository.SaveChanges();
            return newPatient.Id;
        }
        public async Task<long> UpdatePatient(Patient patient)
        {
            _PatientRepository.Update(patient);
            await _PatientRepository.SaveChanges();
            return patient.Id;
        }
        public async Task<long> DeletePatient(int patientId)
        {
            var patient = await _PatientRepository.GetById(patientId);
            _PatientRepository.Remove(patient);
            await _PatientRepository.SaveChanges();
            return patient.Id;
        }
    }
}
