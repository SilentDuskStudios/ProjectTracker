using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Models
{
    public class Issue
    {
        #region " - - - - - - Properties - - - - - - "

        public long ID { get; set; }

        public string Summary { get; set; }
        public PriorityEnum Priority { get; set; }
        [Display(Name = "Date Started")]
        public DateTime DateStart { get; set; }
        [Display(Name = "Date Due")]
        public DateTime DateDue { get; set; }
        public StatusEnum Status { get; set; }

        #endregion
    }

    #region " - - - - - - Enumerators - - - - - - "

    public enum PriorityEnum
    {
        Low,
        Medium,
        High
    }

    public enum StatusEnum
    {
        [Display(Name = "Not Started")]NotStarted,
        [Display(Name = "In Progress")]InProgress,
        Completed
    }
    #endregion
}