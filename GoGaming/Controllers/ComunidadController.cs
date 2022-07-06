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
    public class ComunidadController : BasicController
    {
        // GET: Comunidad
        public ActionResult Index()
        {
            SessionInitialize();
            ComunidadCAD comCad = new ComunidadCAD(session);
            ComunidadCEN comCEN = new ComunidadCEN(comCad);
            IList<ComunidadEN> lista = comCEN.ReadAll(0, 5);

            IEnumerable<ComunidadViewModel> listViewModel = (IEnumerable<ComunidadViewModel>)new ComunidadAssembler().ConvertListENTModel(lista).ToList();
            SessionClose();

            return View(listViewModel);
        }

        public ActionResult IndexPartial(int id)
        {
            SessionInitialize();
            ComunidadCAD comCad = new ComunidadCAD(session);
            ComunidadCEN comCEN = new ComunidadCEN(comCad);
            IList<ComunidadEN> lista = comCEN.GetComunidadesUsuario(id);

            IEnumerable<ComunidadViewModel> listViewModel = (IEnumerable<ComunidadViewModel>)new ComunidadAssembler().ConvertListENTModel(lista).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: Comunidad/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ComunidadCAD comCad = new ComunidadCAD(session);
            ComunidadCEN comCEN = new ComunidadCEN(comCad);
            ComunidadEN lista = comCEN.ReadOID(id);
            ViewData["imagen"] = lista.Juego.Portada;
            //ComunidadViewModel listViewModel = new ComunidadAssembler().ConvertENToModelUI(lista);

            SessionClose();
            if (lista != null)
            {
                ComunidadViewModel listViewModel = new ComunidadAssembler().ConvertENToModelUI(lista);
                return View(listViewModel);
            }
            else
            {
                return RedirectToAction("SinResultados");
            }
        }

        public ActionResult SinResultados()
        {
            return View();
        }

        //[Authorize]
        // GET: Comunidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comunidad/Create
        [HttpPost]
        public ActionResult Create(int id, ComunidadViewModel com)
        {
            try
            {
                // TODO: Add insert logic here

                ComunidadCEN comunidadCEN = new ComunidadCEN();
                comunidadCEN.New_(com.Nombre, com.Descripcion, DateTime.Now, id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //[Authorize]
        // GET: Comunidad/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ComunidadCAD comCad = new ComunidadCAD(session);
            ComunidadCEN comCEN = new ComunidadCEN(comCad);
            ComunidadEN lista = comCEN.ReadOID(id);
            ComunidadViewModel listViewModel = new ComunidadAssembler().ConvertENToModelUI(lista);

            SessionClose();
            return View(listViewModel);
        }

        // POST: Comunidad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ComunidadViewModel com)
        {
            try
            {
                // TODO: Add insert logic here

                ComunidadCEN comunidadCEN = new ComunidadCEN();
                ComunidadEN comunidadEN = comunidadCEN.ReadOID(id);

                comunidadCEN.Modify(id, com.Nombre, com.Descripcion, comunidadEN.FechaCreacion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comunidad/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            ComunidadCAD comCad = new ComunidadCAD(session);
            ComunidadCEN comCEN = new ComunidadCEN(comCad);

            ComunidadEN lista = comCEN.ReadOID(id);
            ComunidadViewModel listViewModel = new ComunidadAssembler().ConvertENToModelUI(lista);
            SessionClose();

            return View(listViewModel);
        }

        // POST: Comunidad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ComunidadCEN comCEN = new ComunidadCEN();
                int juegoId = comCEN.ReadOID(id).Juego.Id;
                new JuegoCEN().DeleteComunidad(juegoId, id);

                comCEN.Destroy(id);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                string excp = e.ToString();
                return View();
            }
        }

    }
}
