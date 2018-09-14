using System;
using System.Linq.Expressions;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public class TaskInfo : DbObject<int>
    { 

        public string Options { get; set; }

        public bool RunNow { get; set; }

        public string Description { get; set; }

        public TimeSpan Interval { get; set; }

        public DateTime LastStartDateTime { get; set; }

        public DateTime LastEndingDateTime { get; set; }

        public DateTime? LastSuccessStartDateTime { get; set; }

        public DateTime? LastSuccessEndDateTime { get; set; }

        public bool IsActive { get; set; }

        public bool IsRunning { get; set; }

        //----------------------------------------------------------------//

        public TaskInfo() {}
    
        //----------------------------------------------------------------//
            

        public TaskInfo(int taskId, string description, TimeSpan interval)
        {
            Id = taskId;
            Description = description;
            Interval = interval;
        }

        //----------------------------------------------------------------//

        public void TaskStarting()
        {
            LastStartDateTime = DateTime.Now;
        }

        //----------------------------------------------------------------//

        public void TaskEnding(bool isSuccess)
        {
            LastEndingDateTime = DateTime.Now;
            if (isSuccess)
            {
                LastSuccessStartDateTime = LastStartDateTime;
                LastSuccessEndDateTime = LastEndingDateTime; 
            }
 
        }

        //----------------------------------------------------------------//

    }

}
