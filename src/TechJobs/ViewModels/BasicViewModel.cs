using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class BasicViewModel
    {
        public List<JobFieldType> Columns { get; set; }

        public string Title { get; set; } = "";

        public BasicViewModel()
        {
           
            Columns = new List<JobFieldType>();

            foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(enumVal);
            }

        }
    }
}
