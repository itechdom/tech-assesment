using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using justice_technical_assestment.Infrastructure.Models;
using justice_technical_assestment.Models;
using justice_technical_assestment.Infrastructure.Services;


namespace justice_technical_assestment.Controllers
{
    [ApiController]
    [Route("")]
    [Authorize]
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
        [Route("patient")]
        public async Task<ResponseResult<List<Patient>>> GetPatients(int? patientId) =>
            await _ClinicService.GetPatients(patientId);

        [HttpPost]
        [Route("patient")]
        public async Task<ResponseResult<Patient>> CreatePatient(PatientRequestDto model) =>
           await _ClinicService.CreatePatient(model);

        [HttpPut]
        [Route("patient")]
        public async Task<ResponseResult<Patient>> UpdatePatient(PatientRequestDto model) =>
           await _ClinicService.UpdatePatient(model);

        [HttpDelete]
        [Route("patient")]
        public async Task<ResponseResult<List<Patient>>> DeletePatient(int patientId) =>
            await _ClinicService.DeletePatient(patientId);

   }
}
