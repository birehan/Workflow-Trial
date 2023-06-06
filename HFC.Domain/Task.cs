using HFC.Domain.Common;
using System.Collections;

namespace HFC.Domain
{
    public class Task : BaseDomainEntity
    {
        // write me fields title, desription, startDate, endDate, status and AppUser user
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Status { get; set; }



        public string CreatorId { get; set; }

        public AppUser Creator { get; set; }
    }
}
