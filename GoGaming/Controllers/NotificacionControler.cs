using GoGaming.Assemblers;
using GoGaming.Models;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.CP.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoGaming.Controllers
{
    public class NotificacionController : BasicController
    {
        // GET: Notificacion
        public ActionResult Index()
        {
            SessionInitialize();
            NotificacionCAD notCAD = new NotificacionCAD(session);
            NotificacionCEN notCEN = new NotificacionCEN(notCAD);

            IList<NotificacionEN> listEN = notCEN.ReadAll(0, -1);
            IEnumerable<NotificacionViewModel> listViewModel = new NotificacionAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            return View(listViewModel);
        }

        // GET: Notificacion/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            NotificacionCAD notCAD = new NotificacionCAD(session);
            NotificacionCEN notCEN = new NotificacionCEN(notCAD);

            NotificacionEN listEN = notCEN.ReadOID(id);
            NotificacionViewModel notViewModel = new NotificacionAssembler().ConvertENToModelUI(listEN);
            SessionClose();
            return View(notViewModel);
        }

        // GET: Notificacion/Create
        public ActionResult Create()
        {
            NotificacionViewModel not = new NotificacionViewModel();
            return View(not);
        }

        // POST: Notificacion/Create
        [HttpPost]
        public ActionResult Create(NotificacionViewModel not)
        {
            try
            {
                // TODO: Add insert logic here
                NotificacionCP notificacionCP = new NotificacionCP();
                notificacionCP.New_(65537);
                //notificacionCP.New_(idPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notificacion/Edit/5
        public ActionResult Edit(int id)
        {
            NotificacionViewModel not = null;
            SessionInitialize();
            NotificacionEN notificacionEN = new NotificacionCAD(session).ReadOIDDefault(id);
            not = new NotificacionAssembler().ConvertENToModelUI(notificacionEN);
            SessionClose();
            return View(not);
        }

        // POST: Notificacion/Edit/5
        [HttpPost]
        public ActionResult Edit(NotificacionViewModel not)
        {
            try
            {
                // TODO: Add update logic here
                NotificacionCEN notificacionCEN = new NotificacionCEN();
                NotificacionEN notificacionEN = notificacionCEN.ReadOID(not.Id);
                notificacionCEN.Modify(not.Id, not.Texto, notificacionEN.Hora);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notificacion/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            NotificacionCAD notCAD = new NotificacionCAD(session);
            NotificacionCEN notCEN = new NotificacionCEN(notCAD);

            NotificacionEN notEN = notCEN.ReadOID(id);
            NotificacionViewModel notViewModel = new NotificacionAssembler().ConvertENToModelUI(notEN);
            SessionClose();
            return View(notViewModel);
        }

        // POST: Notificacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                new NotificacionCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
