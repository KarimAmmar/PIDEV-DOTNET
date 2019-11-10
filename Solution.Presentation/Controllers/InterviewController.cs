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
    public class InterviewController : Controller
    {
        IInterviewService Service = null;
        IAvailabilityService ServiceAv = null;
        public static int InterId = 0;
        public InterviewController()
        {
            Service = new InterviewService();
            ServiceAv = new AvailabilityService();
        }

        // GET: Interview
        public ActionResult Index(string searchBy,string search)
        {
            var inter = new List<InterviewVM>();
            
            foreach (Interview ivm in Service.GetInterviewByLocationAndType(search,searchBy))
                {
                    inter.Add(new InterviewVM()
                    {
                        InterviewId = ivm.InterviewId,
                        User_Id = ivm.User_Id,
                        Candidat_Id = ivm.Candidat_Id,
                        Interview_Date = ivm.Interview_Date,
                        Interview_Location = ivm.Interview_Location,
                        Interview_Type = (TypeVM)ivm.Interview_Type
                    });
                }
            
          
            return View(inter);
        }

        // GET: Interview/Details/5
        public ActionResult Details(int id)
        {
            Interview cl = Service.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);
        }

        // GET: Interview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interview/Create
        [HttpPost]
        public ActionResult Create(InterviewVM ivm)
        {
            Interview interviewdomain = new Interview()
            {
                InterviewId = ivm.InterviewId,
                User_Id = 1,
                Candidat_Id = 1,
                Interview_Date = ivm.Interview_Date,
                Interview_Location = ivm.Interview_Location,
                Interview_Type = (TypeInt)ivm.Interview_Type


            };
            Service.Add(interviewdomain);
            Service.Commit();
            // Service.Dispose();
            return View();

        }

        // GET: Interview/Edit/5
        public ActionResult Edit(int id)
        {
            Interview cl = Service.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);

        }

        // POST: Interview/Edit/5
        [HttpPost]
        public ActionResult Edit(Interview ivm)
        {
            Interview i1 = Service.GetById(ivm.InterviewId);
            i1.InterviewId = ivm.InterviewId;
            i1.User_Id = 1;
            i1.Candidat_Id = ivm.Candidat_Id;
            i1.Interview_Date = ivm.Interview_Date;
            i1.Interview_Location = ivm.Interview_Location;
            i1.Interview_Type = ivm.Interview_Type;

            if (ModelState.IsValid)
            {
                Service.Update(i1);
                Service.Commit();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");


        }

        // GET: Interview/Delete/5
        public ActionResult Delete(int id)
        {
            Interview cl = Service.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);
        }

        // POST: Interview/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Interview cl = Service.GetById(id);
            Service.Delete(cl);
            Service.Commit();

            return RedirectToAction("Index");
        }
        public ActionResult IndexCand()
        {
            var inter = new List<InterviewVM>();
            foreach (Interview ivm in Service.GetInterviewByCandidateId(1))
            {
                if (ivm.Interview_Type == TypeInt.Unscheduled)
                {
                    inter.Add(new InterviewVM()
                    {
                        InterviewId = ivm.InterviewId,
                        User_Id = ivm.User_Id,
                        Candidat_Id = ivm.Candidat_Id,
                        Interview_Location = ivm.Interview_Location,
                        Interview_Type = (TypeVM)ivm.Interview_Type
                    });
                }
                else
                {
                    inter.Add(new InterviewVM()
                    {
                        InterviewId = ivm.InterviewId,
                        User_Id = ivm.User_Id,
                        Candidat_Id = ivm.Candidat_Id,
                        Interview_Date = ivm.Interview_Date,
                        Interview_Location = ivm.Interview_Location,
                        Interview_Type = (TypeVM)ivm.Interview_Type
                    });
                }

            }
            return View(inter);
        }
       
        public ActionResult Calendar(int id)
        {
            InterId = id;
            return View();
        }
        public JsonResult GetEvents()
        {
            var inter = new List<AvailabilityVM>();
            foreach (Availability ivm in ServiceAv.GetMany())
            {
                inter.Add(new AvailabilityVM()
                {
                    AvailabilityId = ivm.AvailabilityId,
                    Representator_Id = ivm.Representator_Id,
                    Availability_Date_Begin = ivm.Availability_Date_Begin,
                    Availability_Date_End = ivm.Availability_Date_End

                });
            }

            return new JsonResult { Data = inter, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public ActionResult ChooseDate(int id)
        {
            Availability cl = ServiceAv.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);
        }

        // POST: Interview/Delete/5
        [HttpPost]
        public ActionResult ChooseDate(int id, FormCollection collection)
        {
            Availability cl = ServiceAv.GetById(id);
            Interview i1 = Service.GetById(InterId);
            i1.Interview_Date = cl.Availability_Date_Begin;
            i1.Interview_Type = TypeInt.Scheduled;
           
                Service.Update(i1);
                Service.Commit();
            
                ServiceAv.Delete(cl);
            ServiceAv.Commit();

            return RedirectToAction("Index");
        }

    }
}
