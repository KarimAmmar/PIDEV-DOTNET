using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class EventController : Controller
    {
        ICompanyService CService = null;
        IEventService EService = null;
        public EventController()
        {
            EService = new EventService();
            CService = new CompanyService();
           
        }
        // GET: Event
        public ActionResult Index()
        {
            var events = new List<EventVM>();

            foreach (Event evm in EService.GetMany())
            {
                events.Add(new EventVM()
                {
                    EventId = evm.EventId,
                    Event_Address = evm.Event_Address,
                    Event_Date = evm.Event_Date,
                    Event_Description = evm.Event_Description,
                    Event_Title = evm.Event_Title,
              
                    NumberOfParticipent = evm.NumberOfParticipent,
                    CompanyId = evm.CompanyId

                


                });
            }

            return View(events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Event evm = EService.GetById(id);
            EventVM e = new EventVM()
            {


                EventId = evm.EventId,
                Event_Address = evm.Event_Address,
                Event_Date = evm.Event_Date,
                Event_Description = evm.Event_Description,
                Event_Title = evm.Event_Title,

                NumberOfParticipent = evm.NumberOfParticipent,
                CompanyId = evm.CompanyId





            };
        
           
            if ( evm== null)
                return HttpNotFound();
            return View(e);

        
    }

        // GET: Event/Create
        public ActionResult Create()
        {
            var Companies = CService.GetMany();
            ViewBag.mycompanies =
            new SelectList(Companies, "CompanyId", "Company_name");
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventVM evm)
        {


            Event newEvent = new Event()
            {
                EventId = evm.EventId,
                Event_Address = evm.Event_Address,
                Event_Date = evm.Event_Date,
                Event_Description = evm.Event_Description,
                Event_Title = evm.Event_Title,
               
                NumberOfParticipent = 0,
                CompanyId = evm.CompanyId


            };

            EService.Add(newEvent);
            EService.Commit();



            return RedirectToAction("Index");
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Event e= EService.GetById(id);
            EventVM evm = new EventVM()
            {


                EventId = e.EventId,
                Event_Address = e.Event_Address,
                Event_Date = e.Event_Date,
                Event_Description = e.Event_Description,
                Event_Title = e.Event_Title,

                NumberOfParticipent = e.NumberOfParticipent,
                CompanyId = e.CompanyId





            };
            if (e == null)
                return HttpNotFound();
            return View(evm);
          
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventVM evm)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



                Event o = EService.GetById(id);


                o.Event_Address = evm.Event_Address;
                o.Event_Date = evm.Event_Date;
                o.Event_Description = evm.Event_Description;
                o.Event_Title = evm.Event_Title;

                o.NumberOfParticipent = evm.NumberOfParticipent;
                o.CompanyId = evm.CompanyId;
              





                if (o == null)
                    return HttpNotFound();


                // Service.UpdateCompany(c);
                EService.Update(o);
                EService.Commit();


                return RedirectToAction("Index");
            }
            // TODO: Add delete logic here
            return View(evm);


              
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Event evm = EService.GetById(id);
            EventVM e = new EventVM()
            {


                EventId = evm.EventId,
                Event_Address = evm.Event_Address,
                Event_Date = evm.Event_Date,
                Event_Description = evm.Event_Description,
                Event_Title = evm.Event_Title,
              
                NumberOfParticipent = evm.NumberOfParticipent,
                CompanyId = evm.CompanyId





            };
            if (evm == null)
                return HttpNotFound();
            return View(e);
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventVM ovm)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Event o = EService.GetById(id);
            //OfferVM ovm = new OfferVM()
            //{
            //    OfferId = o.OfferId,
            //    Offer_Title = o.Offer_Title,
            //    Offer_description = o.Offer_description,
            //    Offre_Duration = o.Offre_Duration,
            //    Offre_Salary = o.Offre_Salary,
            //    Offer_Contract_Type = (ContractTypeVM)o.Offer_Contract_Type,
            //    Offer_Level_Of_Expertise = (OfferLevelVM)o.Offer_Level_Of_Expertise,
            //    Offer_DatePublished = o.Offer_DatePublished,
            //    Vues = o.Vues,
            //    CompanyId = o.CompanyId


            //};


            if (o == null)
                return HttpNotFound();
            EService.Delete(o);
            EService.Commit();


            return RedirectToAction("Index");
        }
    }
}
