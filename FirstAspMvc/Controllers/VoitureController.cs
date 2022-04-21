using GarageOO.DAL.Repositories;
using GarageOO.Models.Concretes;
using FirstAspMvc.Models.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FirstAspMvc.Infra.Mapper;
using System.Linq;
using FirstAspMvc.Models;

namespace FirstAspMvc.Controllers
{
    public class VoitureController : Controller
    {
        public IActionResult Index()
        {
            VoitureRepository repo = new VoitureRepository(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TFGarage;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //demander la liste des voitures de la db
            List<VoitureViewModel> MesVoitures = repo.GetAll().Select(m=>m.ToViewModel()).ToList();


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
                //go to the database
                VoitureRepository repo = new VoitureRepository(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TFGarage;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                if(repo.Add(model.ToBusiness()))
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
    }
}
