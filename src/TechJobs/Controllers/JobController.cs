using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view
            SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();

            jobsViewModel.job= jobData.Find(id);
            jobsViewModel.Title = "job(s) for:";
            return View(jobsViewModel);

        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.


            /*Job newJob = new Job();
                       
            newJob.Name = newJobViewModel.Name;
            foreach(var employer in newJobViewModel.Employers)
            {
                newJob.Employer.Value = employer.Text;
            }

            foreach (var location in newJobViewModel.Locations)
            {
                newJob.Location.Value = location.Text;
            }

            foreach (var corecompetency in newJobViewModel.CoreCompetencies)
            {
                newJob.CoreCompetency.Value = corecompetency.Text;
            }

            foreach (var positiontype in newJobViewModel.PositionTypes)
            {
                newJob.PositionType.Value = positiontype.Text;
            }
            jobData.Jobs.Add(newJob);

            SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();

            jobsViewModel.job = newJob;
            jobsViewModel.Title = "new job for:";

            return View("Index",jobsViewModel);*/
            return View(newJobViewModel);
        }
    }
}
