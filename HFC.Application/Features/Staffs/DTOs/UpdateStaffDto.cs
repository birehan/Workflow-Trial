using HFC.Application.Features.Common;
using static HFC.Domain.Staff;

namespace HFC.Application.Features.Staffs.DTOs
{
    public class UpdateStaffDto : BaseDto, IStaffDto
    {
        public string Name { get; set; }
        public string About { get; set; }

        public Sector UserSector { get; set; }


        public string Title { get; set; }


    }
}