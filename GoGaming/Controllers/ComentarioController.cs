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
            return View(listViewModel);
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ComentarioCAD comentCAD = new ComentarioCAD(session);
            ComentarioCEN comentCEN = new ComentarioCEN(comentCAD);

            ComentarioEN listEN = comentCEN.ReadOID(id);
            ComentarioViewModel comentViewModel = new ComentarioAssembler().ConvertENToModelUI(listEN);
            SessionClose();
            return View(comentViewModel);
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            ComentarioViewModel coment = new ComentarioViewModel();
            return View(coment);
        }

        // POST: Comentario/Create
        [HttpPost]
        public ActionResult Create(ComentarioViewModel coment)
        {
            try
            {
                // TODO: Add insert logic here
                ComentarioCEN comentarioCEN = new ComentarioCEN();
                //Hay que ver como recuperar la id del usuario (se que se puede acceder a los datos del usuario que tiene la sesion iniciada) y la id del post
                comentarioCEN.NewRaiz(coment.Contenido, 32770, 65537, DateTime.Now);
                //comentarioCEN.NewRaiz(coment.Contenido, ((UsuarioEN)Session["Usuario"]).Id, idPost, DateTime.Now);
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
            ComentarioViewModel coment = null;
            SessionInitialize();
            ComentarioEN comentarioEN = new ComentarioCAD(session).ReadOIDDefault(id);
            coment = new ComentarioAssembler().ConvertENToModelUI(comentarioEN);
            SessionClose();
            return View(coment);
        }

        // POST: Comentario/Edit/5
        [HttpPost]
        public ActionResult Edit(ComentarioViewModel coment)
        {
            try
            {
                // TODO: Add update logic here
                ComentarioCEN comentarioCEN = new ComentarioCEN();
                comentarioCEN.Modify(coment.Id, coment.Contenido, DateTime.Now);
                //comentarioCEN.Modify(coment.Id, coment.Contenido, coment.Hora);
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
            SessionInitialize();
            ComentarioCAD comentCAD = new ComentarioCAD(session);
            ComentarioCEN comentCEN = new ComentarioCEN(comentCAD);

            ComentarioEN listEN = comentCEN.ReadOID(id);
            ComentarioViewModel comentViewModel = new ComentarioAssembler().ConvertENToModelUI(listEN);
            SessionClose();
            return View(comentViewModel);
        }

        // POST: Comentario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                new ComentarioCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
