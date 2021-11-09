using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OperaWebSite.Models;
using OperaWebSite.Data;
using System.Data.Entity;
using System.Diagnostics;
using OperaWebSite.Filter;

namespace OperaWebSite.Controllers
{
    [MyFilterAction]
    public class OperaController : Controller
    {

        //Crear instancia de dbContext
        private OperaDbContext context = new OperaDbContext();

        // GET: Opera
        [MyFilterAction]
        public ActionResult Index()
        {
            var operas = context.Operas.ToList();


            //el controller devuelve una lista "Index" con la lista de operas
            return View("Index", operas);
        }
        [MyFilterAction]
        [HttpGet]//YA ESTA IMPLICITO, NO ES NECESARIO PONERLO
        public ActionResult Create()
        {
            Opera opera = new Opera();

            //Retornamos la vista "create" que tiene el objeto opera
            return View("Create", opera);
        }


        //Opera/Create --> POST
        [MyFilterAction]
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", opera);
        }

        //Opera/Detail/id --> GET
        //[HttpGet] otra vez opcional xq por default ya es GET
        [MyFilterAction]
        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);
            if(opera != null)
            {
                return View("Detail", opera);
            }
            return HttpNotFound();
        }
        //Opera/Delete/id --> GET
        //[HttpGet]
        [MyFilterAction]
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);

            if(opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //Opera/Delete  --> POST
        [MyFilterAction]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);

            context.Operas.Remove(opera);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Opera/Edit --> Get
        [MyFilterAction]
        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);
            if(opera != null)
            {
                return View("Edit", opera);
            }
            return HttpNotFound();
        }

        //Opera/Edit --> POST
        [MyFilterAction]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", opera);
        }


    }
}