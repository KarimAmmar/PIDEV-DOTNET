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
    public class AvailabilityController : Controller
    {
        IAvailabilityService Service = null;
        public AvailabilityController()
        {
            Service = new AvailabilityService();
        }

        // GET: Availability
        public ActionResult Index()
        {
            var inter = new List<AvailabilityVM>();
            foreach (Availability ivm in Service.GetMany())
            {
                inter.Add(new AvailabilityVM()
                {
                    AvailabilityId = ivm.AvailabilityId,
                    Representator_Id = ivm.Representator_Id,
                    Availability_Date_Begin = ivm.Availability_Date_Begin,
                    Availability_Date_End = ivm.Availability_Date_End

                });
            }
            return View(inter);
        }

        // GET: Availability/Details/5
        public ActionResult Details(int id)
        {
            Availability cl = Service.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);
        }

        // GET: Availability/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Availability/Create
        [HttpPost]
        public ActionResult Create(AvailabilityVM ivm)
        {
            Availability Availabilitydomain = new Availability()
            {
                AvailabilityId = ivm.AvailabilityId,
                Representator_Id = 1,
                Availability_Date_Begin = ivm.Availability_Date_Begin,
                Availability_Date_End = ivm.Availability_Date_Begin


            };
            Service.Add(Availabilitydomain);
            Service.Commit();
            // Service.Dispose();
            return View();

        }

        // GET: Availability/Edit/5
        public ActionResult Edit(int id)
        {
            Availability cl = Service.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);

        }

        // POST: Availability/Edit/5
        [HttpPost]
        public ActionResult Edit(Availability ivm)
        {
            Availability i1 = Service.GetById(ivm.AvailabilityId);
            i1.AvailabilityId = ivm.AvailabilityId;
            i1.Representator_Id = ivm.Representator_Id;
            i1.Availability_Date_Begin = ivm.Availability_Date_Begin;
            i1.Availability_Date_End = ivm.Availability_Date_End;

            if (ModelState.IsValid)
            {
                Service.Update(i1);
                Service.Commit();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");


        }

        // GET: Availability/Delete/5
        public ActionResult Delete(int id)
        {
            Availability cl = Service.GetById(id);
            if (cl == null)
            {

                return HttpNotFound();

            }

            return View(cl);
        }

        // POST: Availability/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Availability cl = Service.GetById(id);
            Service.Delete(cl);
            Service.Commit();

            return RedirectToAction("Index");
        }
        public ActionResult Calendar()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            var inter = new List<AvailabilityVM>();
            foreach (Availability ivm in Service.GetMany())
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
    }
}
