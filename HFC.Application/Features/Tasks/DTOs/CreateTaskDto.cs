using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HFC.Application.Features.Tasks.DTOs
{
    public class CreateTaskDto : ITaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }
    }
}