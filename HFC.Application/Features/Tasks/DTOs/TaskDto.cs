using HFC.Application.Features.Common;

namespace HFC.Application.Features.Tasks.DTOs
{
    public class TaskDto: BaseDto, ITaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }

        public string CreatorUsername { get; set; }


    }
}