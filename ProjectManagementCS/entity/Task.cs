using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManagementCS.entity
{
    public class EntityTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; }
        public DateTime AllocationDate { get; set; }
        public DateTime DeadlineDate { get; set; }
    }
}
