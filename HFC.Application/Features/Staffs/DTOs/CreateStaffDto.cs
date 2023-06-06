using Microsoft.AspNetCore.Http;
using static HFC.Domain.Staff;

namespace HFC.Application.Features.Staffs.DTOs
{
    public class CreateStaffDto : IStaffDto
    {

        public string Name { get; set; }
        public string About { get; set; }
        public IFormFile File { get; set; }

        public Sector UserSector { get; set; }

        public string Title { get; set; }

    }
}