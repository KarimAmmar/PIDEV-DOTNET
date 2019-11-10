using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class ApplicationController : Controller
    {
        IApplicationService Service = null;
        IInterviewService ServiceI = null;
        public ApplicationController()
        {
            Service = new ApplicationService();
            ServiceI = new InterviewService();
        }
        // GET: Application
        public ActionResult Index()
        {
            var inter = new List<ApplicationVM>();

            foreach (Application ivm in Service.GetMany())
            {
                inter.Add(new ApplicationVM()
                {
                    ApplicationId = ivm.ApplicationId,
                    Candidat_Id = ivm.Candidat_Id,
                    Job_Offer_Id = ivm.Job_Offer_Id,
                    Application_Date = ivm.Application_Date,
                    Application_Description = ivm.Application_Description,
                    Application_Status = ivm.Application_Status
                });
            }
            return View(inter);
        }
        public ActionResult Accept(int id)
        {
            Application appli = Service.GetById(id);
            Interview interviewdomain = new Interview()
            {
               
                User_Id = 1,
                Candidat_Id = appli.Candidat_Id,
                Interview_Date = DateTime.Now,
                Interview_Location = "Not Located",
                Interview_Type = TypeInt.Unscheduled


            };
            ServiceI.Add(interviewdomain);
            ServiceI.Commit();
            
            appli.Application_Status = "Accepted";

            Service.Update(appli);
            Service.Commit();

             return RedirectToAction("Index");
        }
        // GET: Application/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Application/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Application/Delete/5
        public ActionResult Delete(int id)
        {
            Application cl = Service.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);
        }

        // POST: Application/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Application cl = Service.GetById(id);
            Service.Delete(cl);
            Service.Commit();

            return RedirectToAction("Index");
        }
    }
}
