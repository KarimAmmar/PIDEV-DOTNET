using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Mvc;
using static Solution.Domain.Entities.Offer;
using static Solution.Presentation.Models.OfferVM;

namespace Solution.Presentation.Controllers
{
    public class OfferController : Controller
    {
        IOfferService OService = null;
        ICompanyService CService = null;
        public OfferController()
        {
            OService = new OfferService();
            CService = new CompanyService();
        }
        // GET: Offer
        public ActionResult Index(string searchString)
        {
            var offers = new List<OfferVM>();
            IEnumerable<Company> companies = CService.GetMany().ToList();
            ViewBag.data = companies;
            IEnumerable<Offer> offresD = OService.GetMany();
            if (searchString!="")
            {
                offresD = offresD.Where(o => o.Offer_Contract_Type.Equals(searchString)).ToList();
            }

            

            foreach (Offer ovm in OService.GetMany())
            {
                offers.Add(new OfferVM()
                {
                    OfferId = ovm.OfferId,
                    Offer_Title = ovm.Offer_Title,
                    Offer_description = ovm.Offer_description,
                    Offre_Duration = ovm.Offre_Duration,
                    Offre_Salary = ovm.Offre_Salary,
                    Offer_Contract_Type = (ContractTypeVM)ovm.Offer_Contract_Type,
                    Offer_Level_Of_Expertise = (OfferLevelVM)ovm.Offer_Level_Of_Expertise,
                    Offer_DatePublished = ovm.Offer_DatePublished,
                    Vues = ovm.Vues,
                    CompanyId = ovm.CompanyId


                });
            }

            return View(offers);
        }

        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
            IEnumerable<Company> companies = CService.GetMany().ToList();
            ViewBag.data = companies;
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Offer o = OService.GetById(id);
            OfferVM ovm = new OfferVM()
            {
                OfferId = o.OfferId,
                Offer_Title = o.Offer_Title,
                Offer_description = o.Offer_description,
                Offre_Duration = o.Offre_Duration,
                Offre_Salary = o.Offre_Salary,
                Offer_Contract_Type = (ContractTypeVM)o.Offer_Contract_Type,
                Offer_Level_Of_Expertise = (OfferLevelVM)o.Offer_Level_Of_Expertise,
                Offer_DatePublished = o.Offer_DatePublished,
                Vues = o.Vues,
                CompanyId = o.CompanyId


            };
            o.Vues = o.Vues + 1;
            OService.Update(o);
            OService.Commit();
            if (o == null)
                return HttpNotFound();
            return View(ovm);

        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            var Companies = CService.GetMany();
            ViewBag.mycompanies =
            new SelectList(Companies, "CompanyId", "Company_name");
            return View();
        }

        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(OfferVM ovm)
        {





            Offer newoffer = new Offer()
            {
                OfferId = ovm.OfferId,
                Offer_Title = ovm.Offer_Title,
                Offer_description = ovm.Offer_description,
                Offre_Duration = ovm.Offre_Duration,
                Offre_Salary = ovm.Offre_Salary,
                Offer_Contract_Type = (ContractType)ovm.Offer_Contract_Type,
                Offer_Level_Of_Expertise = (OfferLevel)ovm.Offer_Level_Of_Expertise,
                Offer_DatePublished = DateTime.Now,
                Vues = 0,
                CompanyId = ovm.CompanyId



            };

            OService.Add(newoffer);
            OService.Commit();



            return RedirectToAction("Index");
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Offer o = OService.GetById(id);
            OfferVM ovm = new OfferVM()
            {

                Offer_Title = o.Offer_Title,
                Offer_description = o.Offer_description,
                Offre_Duration = o.Offre_Duration,
                Offre_Salary = o.Offre_Salary,
                Offer_Contract_Type = (ContractTypeVM)o.Offer_Contract_Type,
                Offer_Level_Of_Expertise = (OfferLevelVM)o.Offer_Level_Of_Expertise,

                CompanyId = o.CompanyId


            };
            if (o == null)
                return HttpNotFound();
            return View(ovm);
        }

        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OfferVM ovm)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                Offer o = OService.GetById(id);
                o.Offer_description = ovm.Offer_description;
                o.Offre_Duration = ovm.Offre_Duration;
                o.Offre_Salary = ovm.Offre_Salary;
                o.Offer_Contract_Type = (ContractType)ovm.Offer_Contract_Type;
                o.Offer_Level_Of_Expertise = (OfferLevel)ovm.Offer_Level_Of_Expertise;


                o.CompanyId = ovm.CompanyId;





                if (o == null)
                    return HttpNotFound();


                // Service.UpdateCompany(c);
                OService.Update(o);
                OService.Commit();


                return RedirectToAction("Index");
            }
            // TODO: Add delete logic here
            return View(ovm);
        }

        // GET: Offer/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Offer o = OService.GetById(id);
            OfferVM ovm = new OfferVM()
            {
                OfferId = o.OfferId,
                Offer_Title = o.Offer_Title,
                Offer_description = o.Offer_description,
                Offre_Duration = o.Offre_Duration,
                Offre_Salary = o.Offre_Salary,
                Offer_Contract_Type = (ContractTypeVM)o.Offer_Contract_Type,
                Offer_Level_Of_Expertise = (OfferLevelVM)o.Offer_Level_Of_Expertise,
                Offer_DatePublished = o.Offer_DatePublished,
                Vues = o.Vues,
                CompanyId = o.CompanyId


            };
            if (o == null)
                return HttpNotFound();
            return View(ovm);
        }

        // POST: Offer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OfferVM ovm)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Offer o = OService.GetById(id);
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
            OService.Delete(o);
            OService.Commit();


            return RedirectToAction("Index");
        }
    }
}
