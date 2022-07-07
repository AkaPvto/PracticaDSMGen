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
    public class AvisoController : BasicController
    {
        // GET: Aviso
        public ActionResult Index()
        {
            SessionInitialize();
            AvisoCAD avisoCAD = new AvisoCAD(session);
            AvisoCEN avisoCEN = new AvisoCEN(avisoCAD);

            IList<AvisoEN> listEN = avisoCEN.ReadAll(0, -1);
            IEnumerable<AvisoViewModel> listViewModel = new AvisoAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            return View(listViewModel);
        }

        public ActionResult IndexUsuario(int idUsuario)
        {
            SessionInitialize();
            AvisoCAD avisoCAD = new AvisoCAD(session);
            AvisoCEN avisoCEN = new AvisoCEN(avisoCAD);

            IList<AvisoEN> listEN = avisoCEN.GetAvisosUsu(idUsuario);
            IEnumerable<AvisoViewModel> listViewModel = new AvisoAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            return View(listViewModel);
        }

        // GET: Aviso/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            AvisoCAD avisoCAD = new AvisoCAD(session);
            AvisoCEN avisoCEN = new AvisoCEN(avisoCAD);

            AvisoEN listEN = avisoCEN.ReadOID(id);
            AvisoViewModel avisoViewModel = new AvisoAssembler().ConvertENToModelUI(listEN);
            SessionClose();
            return View(avisoViewModel);
        }

        // GET: Aviso/Create
        public ActionResult Create()
        {
            AvisoViewModel aviso = new AvisoViewModel();
            return View(aviso);
        }

        // POST: Aviso/Create
        [HttpPost]
        public ActionResult Create(AvisoViewModel aviso)
        {
            try
            {
                // TODO: Add insert logic here
                AvisoCEN avisoCEN = new AvisoCEN();
                //avisoCEN.New_(aviso.Texto, ((UsuarioEN)Session["Usuario"]).Id, DateTime.Now);
                avisoCEN.New_(aviso.Texto, 32770, DateTime.Now);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aviso/Edit/5
        public ActionResult Edit(int id)
        {
            AvisoViewModel aviso = null;
            SessionInitialize();
            AvisoEN avisoEN = new AvisoCAD(session).ReadOIDDefault(id);
            aviso = new AvisoAssembler().ConvertENToModelUI(avisoEN);
            SessionClose();
            return View(aviso);
        }

        // POST: Aviso/Edit/5
        [HttpPost]
        public ActionResult Edit(AvisoViewModel aviso)
        {
            try
            {
                // TODO: Add update logic here
                AvisoCEN avisoCEN = new AvisoCEN();
                avisoCEN.Modify(aviso.Id, aviso.Texto, DateTime.Now);
                //avisoCEN.Modify(aviso.Id, aviso.Texto, aviso.Hora);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aviso/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            AvisoCAD avisoCAD = new AvisoCAD(session);
            AvisoCEN avisoCEN = new AvisoCEN(avisoCAD);

            AvisoEN listEN = avisoCEN.ReadOID(id);
            AvisoViewModel avisoViewModel = new AvisoAssembler().ConvertENToModelUI(listEN);
            SessionClose();
            return View(avisoViewModel);
        }

        // POST: Aviso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                new AvisoCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
