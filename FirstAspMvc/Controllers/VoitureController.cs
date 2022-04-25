using GarageOO.DAL.Repositories;
using GarageOO.Models.Concretes;
using FirstAspMvc.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FirstAspMvc.Infra.Mapper;
using System.Linq;
using FirstAspMvc.Models;
using GarageOO.DAL.Repositories.Interface;

namespace FirstAspMvc.Controllers
{
    public class VoitureController : Controller
    {
        private readonly IVoitureRepository _repo;
        public VoitureController(IVoitureRepository vr)
        {
            _repo = vr;
        }


        public IActionResult Index()
        {
             
            List<VoitureViewModel> MesVoitures = _repo.GetAll().Select(m=>m.ToViewModel()).ToList();

            if(TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.Success = TempData["SuccessMessage"];
            }

            return View(MesVoitures);
        }
        [HttpGet] //L'action pour l'affichage du formulaire
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //L'action pour le traitement du formulaire
      
        public IActionResult Create(VoitureCreateViewModel model)
        {

            //tester la validité de mon model
           if(ModelState.IsValid)
            {
                 if(_repo.Add(model.ToBusiness()))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                ViewBag.Message = "Erreur lors de l'enregistrement en DB";
                return View(model);
            }

            
        }
    
        [HttpGet]
        public IActionResult Edit(int id)
        {
            /*Récupération via le repo de la bagnole*/
              VoitureCreateViewModel vcvm = _repo.GetOne(id).ToCreateViewModel();

            //ENVOYER LE MODEL!!!!!!!
          return View(vcvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VoitureCreateViewModel toInsert, int id)
        {
                      


            if (!ModelState.IsValid) return View();

            
            //Vérifier si l'id est un id que je connais dans la db
            if(_repo.GetOne(id)!=null)
            {

                if(_repo.Update(toInsert.ToBusiness()))
                {
                    TempData["SuccessMessage"] = "Voiture mise à jour";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage("Impossible de mettre à jour");
                    return View();
                }
 
            }
            else
            {
                //Manipulation de l'id par un C***
                ViewBag.ErrorMessage("Votre formulaire n'est pas correctement envoyé");
                return View();
            }

            
        }
    }
}
