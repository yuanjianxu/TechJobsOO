using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class SearchJobsViewModel :BasicViewModel
    {
        public List<Job> Jobs { get; set; }
        public Job job { get; set; }

        public JobFieldType Column { get; set; } = JobFieldType.All;

        [Display(Name = "Keyword:")]
        public string Value { get; set; } = "";
   
    }
}
