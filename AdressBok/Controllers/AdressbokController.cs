using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AdressBok.Models;
using AdressBokRepositories.Repositories;

namespace AdressBok.Controllers
{
    public class AdressbokController : Controller
    {
        public static AdressBokRepository AdressBokRepository { get; set; }
        public AdressbokController()
        {
            AdressBokRepository = new AdressBokRepository();
        }
        // GET: Adressbok
        public ActionResult Index()
        {
            return View(AdressBokRepository.Adressboks);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(AdressbokView addbok)
        {
            var add = new AdressBokRepositories.Models.AdressBok
            {
                Id = Guid.NewGuid(),
                Name = addbok.Name,
                Telefonnummer = addbok.Telefonnummer,
                Adress = addbok.Adress,
                UpdateAd = addbok.UpdateAd
            };
            AdressBokRepository.Add(add);


            return PartialView("List", AdressBokRepository.Adressboks);
        }

        //[HttpGet]
        //public ActionResult Details()
        //{
        //    var detail = ABRepository.Adressboks.FirstOrDefault(g => g.ID == id);
        //    return PartialView("Details", detail);
        //}

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detail = AdressBokRepository.Adressboks.FirstOrDefault(g => g.Id == id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", detail);
        }
        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            var edititem = AdressBokRepository.Adressboks.FirstOrDefault(g => g.Id == id);
            return PartialView(edititem);
        }
        [HttpPost]
        public ActionResult Edit(AdressBokRepositories.Models.AdressBok editbok)
        {
            if (ModelState.IsValid)
            {
                var add = new AdressBokRepositories.Models.AdressBok
                {
                    Name = editbok.Name,
                    Telefonnummer = editbok.Telefonnummer,
                    Adress = editbok.Adress,
                    UpdateAd = editbok.UpdateAd
                };
                AdressBokRepository.Add(add);
            }

            return PartialView("List", AdressBokRepository.Adressboks);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {

            AdressBokRepository.Remove(id);

            return PartialView("list", AdressBokRepository.Adressboks);
        }

        public ActionResult List()
        {
            return PartialView("list", AdressBokRepository.Adressboks);
        }
    }
}