using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;
using System;
using System.Collections;
using System.Collections.Generic;

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

            JobData jobData = JobData.GetInstance();

            Employer employer = new Employer();
            employer = jobData.Employers.Find(newJobViewModel.EmployerID);

            Location location = new Location();
            location = jobData.Locations.Find(newJobViewModel.LocationID);

            CoreCompetency coreCompetency = new CoreCompetency();
            coreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID);

            PositionType positionType = new PositionType();
            positionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID) ;

            Job newJob = new Job();
            newJob.Name = newJobViewModel.Name;
            newJob.Employer = employer;
            newJob.Location = location;
            newJob.CoreCompetency = coreCompetency;
            newJob.PositionType = positionType;

            if (newJob.Name != null)
            {
               
                jobData.Jobs.Add(newJob);

                SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();

                //jobsViewModel.job = newJob;
                //jobsViewModel.Title = "job for:" ;
                int id = newJob.ID;
                return Redirect("/job?id="+id);
                //return View("Index", jobsViewModel);
            }

            
            return View(newJobViewModel);
        
        }
    }
}
