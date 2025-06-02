using APBD_tutorial_10.Application.DTOs;

namespace APBD_tutorial_10.Application.Service.Interfaces;

public interface IPrescriptionService
{
    Task<(bool IsSuccess, string ErrorMessage)> IssuePrescriptionAsync(PrescriptionRequestDto request);
}
