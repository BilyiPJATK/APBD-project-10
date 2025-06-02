using APBD_tutorial_10.Application.DTOs;
using APBD_tutorial_10.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBD_tutorial_10.Presentation.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            var patientDetails = await _patientService.GetPatientDetailsAsync(id);
            if (patientDetails == null)
                return NotFound();

            return Ok(patientDetails);
        }
    }
}