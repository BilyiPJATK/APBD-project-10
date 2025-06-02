using APBD_tutorial_10.Application.DTOs;
using APBD_tutorial_10.Application.Exceptions;
using APBD_tutorial_10.Application.Service;
using APBD_tutorial_10.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBD_tutorial_10.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost]
    public async Task<IActionResult> IssuePrescription([FromBody] PrescriptionRequestDto request)
    {
        if (request == null)
            return BadRequest("Request body is missing.");

        if (request.Medicaments == null || !request.Medicaments.Any())
            return BadRequest("At least one medicament is required.");

        if (request.Medicaments.Count > 10)
            return BadRequest("A prescription can include a maximum of 10 medicaments.");

        if (request.DueDate < request.Date)
            return BadRequest("DueDate must be greater than or equal to Date.");

        try
        {
            var result = await _prescriptionService.IssuePrescriptionAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok("Prescription issued successfully.");
        }
        catch (PrescriptionExceptions.MedicamentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (DoctorNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (PrescriptionExceptions.TooManyMedicamentsException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (PrescriptionExceptions.InvalidDateException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected error occurred.");
        }
    }

}