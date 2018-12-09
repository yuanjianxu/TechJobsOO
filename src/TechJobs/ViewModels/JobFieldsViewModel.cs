using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel:BasicViewModel
    {
        public JobFieldType Column { get; set; } 

        public IEnumerable<JobField> Fields { get; set; }

    }
}
