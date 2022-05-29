using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using justice_technical_assestment.Infrastructure.Models;
using justice_technical_assestment.Models;
using justice_technical_assestment.Infrastructure.Services;


namespace justice_technical_assestment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class ClinicController : ControllerBase
    {
        private readonly IdentityService _IdentityService;

        public ClinicService _ClinicService { get; }

        public ClinicController(ClinicService ClinicService,
            IdentityService identityService)
        {
            _ClinicService = ClinicService;
            this._IdentityService = identityService;
        }
        [HttpGet]
        [Route("")]
        public async Task<List<Patient>> GetPatients(int? patientId) =>
            await _ClinicService.GetPatients(patientId);

        [HttpGet]
        [Route("doctors")]
        public async Task<List<Doctor>> GetDoctors(int? doctorId) =>
            await _ClinicService.GetDoctors(doctorId);

        [HttpPost]
        [Route("")]
        public async Task<long> CreatePatient(PatientRequestDto model) =>
           await _ClinicService.CreatePatient(model);

        [HttpPut]
        [Route("")]
        public async Task<long> UpdatePatient(Patient model) =>
           await _ClinicService.UpdatePatient(model);

        [HttpDelete]
        [Route("")]
        public async Task<long> DeletePatient(int Id) =>
            await _ClinicService.DeletePatient(Id);

    }
}
