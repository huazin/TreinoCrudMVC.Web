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
    public class EditoraController : Controller
    {
        public EditoraRepository Repo = new EditoraRepository();
        // GET: Editora
        public ActionResult Index()
        {
            return View(MapToViewList(Repo.List() ));
        }

        // GET: Editora/Details/5
        public ActionResult Details(int id)
        {
            return View(MapToView(Repo.FindById(id)));
        }

        // GET: Editora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editora/Create
        [HttpPost]
        public ActionResult Create(EditoraViewModel editora)
        {
            if (ModelState.IsValid)
            {
                Repo.Add(MapToDomain(editora));
                return RedirectToAction("Index");
            }
                return View(editora);
        }

        // GET: Editora/Edit/5
        public ActionResult Edit(int id)
        {
            return View(MapToView(Repo.FindById(id) ));
        }

        // POST: Editora/Edit/5
        [HttpPost]
        public ActionResult Edit(EditoraViewModel editora)
        {
            if(ModelState.IsValid)
            {
                Repo.Edit(MapToDomain(editora));
                return RedirectToAction("Index");
            }
                return View(editora);
        }

        // GET: Editora/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MapToView(Repo.FindById(id) ));
        }

        // POST: Editora/Delete/5
        [HttpPost]
        public ActionResult Delete(EditoraViewModel editora)
        {
            if(ModelState.IsValid)
            {
                Repo.Remove(MapToDomain(editora));
                return RedirectToAction("Index");
            }
            return View(editora);
        }

        public EditoraViewModel MapToView(Editora editora)
        { return Mapper.Map<EditoraViewModel>(editora);}

        public Editora MapToDomain(EditoraViewModel editora)
        { return Mapper.Map<Editora>(editora); }

        public IEnumerable<EditoraViewModel> MapToViewList(IEnumerable<Editora> editora)
        { return Mapper.Map<IEnumerable<EditoraViewModel>>(editora); }
    }
}
