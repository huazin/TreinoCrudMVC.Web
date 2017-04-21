using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinoCrudMVC.Domain;
using TreinoCrudMVC.Infra.Repository;
using TreinoCrudMVC.Web.ViewModel;

namespace TreinoCrudMVC.Web.Controllers
{
    public class GeneroController : Controller
    {
        public GeneroRepository Repo = new GeneroRepository();

        // GET: Genero
        public ActionResult Index()
        {
            return View(MapToViewList(Repo.List()));
        }

        // GET: Genero/Details/5
        public ActionResult Details(int id)
        {
            return View(MapToView(Repo.FindById(id)));
        }

        // GET: Genero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genero/Create
        [HttpPost]
        public ActionResult Create(GeneroViewModel genero)
        {
            if (ModelState.IsValid)
            {
                
                Repo.Add(Mapper.Map<Genero>(genero));
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        // GET: Genero/Edit/5
        public ActionResult Edit(int id)
        {
            return View(MapToView(Repo.FindById(id)));
        }

        // POST: Genero/Edit/5
        [HttpPost]
        public ActionResult Edit(GeneroViewModel genero)
        {
            if (ModelState.IsValid)
            {
                Repo.Edit(Mapper.Map<GeneroViewModel, Genero>(genero));
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        // GET: Genero/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MapToView(Repo.FindById(id)));
        }

        // POST: Genero/Delete/5
        [HttpPost]
        public ActionResult Delete(GeneroViewModel genero)
        {
            if(ModelState.IsValid)
            {
                Repo.Remove(Mapper.Map<GeneroViewModel, Genero>(genero));
                return RedirectToAction("Index");
            }            
            return View(genero);

        }

        //Funções para reaproveita codigo
        public GeneroViewModel MapToView(Genero genero)
        {   return Mapper.Map<Genero, GeneroViewModel>(genero);}
        public IEnumerable<GeneroViewModel> MapToViewList(IEnumerable<Genero> genero)
        {   return Mapper.Map
                <IEnumerable<Genero>, IEnumerable<GeneroViewModel>>(genero);}
    }
}
