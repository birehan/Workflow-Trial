using HFC.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using static HFC.Domain.Staff;

namespace HFC.Application.Features.Staffs.CQRS.Commands
{
    public class UpdateStaffPhotoCommand : IRequest<Result<Unit>>
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }

    }
}
