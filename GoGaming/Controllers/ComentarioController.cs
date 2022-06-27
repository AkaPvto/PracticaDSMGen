using GoGaming.Assemblers;
using GoGaming.Models;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoGaming.Controllers
{
    public class ComentarioController : BasicController
    {
        // GET: Comentario
        public ActionResult Index()
        {
            SessionInitialize();
            ComentarioCAD comentCAD = new ComentarioCAD(session);
            ComentarioCEN comentCEN = new ComentarioCEN(comentCAD);

            IList<ComentarioEN> listEN = comentCEN.ReadAll(0, -1);
            IEnumerable<ComentarioViewModel> listViewModel = new ComentarioAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            return View();
            
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comentario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comentario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comentario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
