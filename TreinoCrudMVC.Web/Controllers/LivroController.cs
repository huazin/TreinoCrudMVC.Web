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
    public class LivroController : Controller
    {
        LivroRepository Repo = new LivroRepository();
        // GET: Livro
        public ActionResult Index()
        {
            return View(MapToList(Repo.List()));
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            return View(MapToView(Repo.FindById(id)));
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            var Genero = new GeneroRepository().List();
            var Editora = new EditoraRepository().List();
            ViewBag.Genero = Genero.Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.GeneroId.ToString()
            }); ;
            ViewBag.Editora = Editora.Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.EditoraId.ToString()
            }); ;
            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                Repo.Add(MapToDomain(livro));
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {

            var Genero = new GeneroRepository().List();
            var Editora = new EditoraRepository().List();
            ViewBag.Genero = Genero.Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.GeneroId.ToString()
            }); ;
            ViewBag.Editora = Editora.Select(x => new SelectListItem()
            {
                Text = x.Nome,
                Value = x.EditoraId.ToString()
            }); ;
            return View(MapToView(Repo.FindById(id)));
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(LivroViewModel livro)
        {
            if(ModelState.IsValid)
            {
                Repo.Edit(MapToDomain(livro));
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(livro);
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(LivroViewModel livro)
        {
            if(ModelState.IsValid)
            {
                Repo.Remove(MapToDomain(livro));
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        public LivroViewModel MapToView(Livro livro)
        { return Mapper.Map<LivroViewModel>(livro); }
        public IEnumerable<LivroViewModel> MapToList(IEnumerable<Livro> livro)
        { return Mapper.Map<IEnumerable<LivroViewModel>>(livro); }

        public Livro MapToDomain(LivroViewModel livro)
        { return Mapper.Map<Livro>(livro); }

    }
}
