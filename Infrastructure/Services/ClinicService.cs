using justice_technical_assestment.Infrastructure.Models;
using justice_technical_assestment.Models;


namespace justice_technical_assestment.Infrastructure.Services
{
    public class ClinicService
    {
        private readonly IHttpContextAccessor _context;
        public IdentityService _IdentityService { get; }
        public string _AppBaseUrl => $"{_context.HttpContext.Request.Scheme}://{_context.HttpContext.Request.Host}{_context.HttpContext.Request.PathBase}";

        public string _headerLanguage => _context.HttpContext.Request.Headers["accept-language"].ToString() ?? "ar";

        private readonly IConfiguration _Configuration;

        public ClinicService(
            IdentityService identityService,
            IHttpContextAccessor context,
            IConfiguration configuration
            )
        {
            _IdentityService = identityService;
            _context = context;
            _Configuration = configuration;
        }

        public async Task<ResponseResult<List<Patient>>> GetPatients(int? patientId)
        {
            // var obj = new ResponseResult<List<ParcelDefinition>>();
            // var mobileNo = _IdentityService.BasicCustomerInfo.MobileNumber;
            // obj.ResponseData = await _PackageDefinitionProxyService.GetParcelDefinitionByMobileNO(mobileNo);
            // return obj;
            return new ResponseResult<List<Patient>>(){};
        }
        public async Task<ResponseResult<Patient>> CreatePatient(PatientRequestDto patient)
        {
            // var obj = new ResponseResult<List<ParcelDefinition>>();
            // var mobileNo = _IdentityService.BasicCustomerInfo.MobileNumber;
            // obj.ResponseData = await _PackageDefinitionProxyService.GetParcelDefinitionByMobileNO(mobileNo);
            // return obj;
            return new ResponseResult<Patient>(){};
        }

        public async Task<ResponseResult<Patient>> UpdatePatient(PatientRequestDto patient)
        {
            // var obj = new ResponseResult<List<ParcelDefinition>>();
            // var mobileNo = _IdentityService.BasicCustomerInfo.MobileNumber;
            // obj.ResponseData = await _PackageDefinitionProxyService.GetParcelDefinitionByMobileNO(mobileNo);
            // return obj;
            return new ResponseResult<Patient>(){};
        }
        public async Task<ResponseResult<List<Patient>>> DeletePatient(int patientId)
        {
            // var obj = new ResponseResult<List<ParcelDefinition>>();
            // var mobileNo = _IdentityService.BasicCustomerInfo.MobileNumber;
            // obj.ResponseData = await _PackageDefinitionProxyService.GetParcelDefinitionByMobileNO(mobileNo);
            // return obj;
            return new ResponseResult<List<Patient>>(){};
        }

        internal async Task<bool> isValidPatient(int patientId){
            //takes the id of the doctor and returns whether this patient belongs to him
            return true;
        }
    }
}
