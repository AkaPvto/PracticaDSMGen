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
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {
            SessionInitialize();

            JuegoCAD juCAD = new JuegoCAD(session);
            JuegoCEN juCEN = new JuegoCEN(juCAD);

            IList<JuegoEN> listEN = juCEN.ReadAll(0, -1);
            IList<JuegoEN> revList = new List<JuegoEN>();
            for (int i = listEN.Count() - 1; i >= 0; i--)
            {
                revList.Add(listEN.ElementAt(i));
                if (i < listEN.Count() - 9)
                {
                    break;
                }
            }
            ViewData["JuegoReci"] = listEN;
            ViewData["iter"] = 0;

            ComunidadCAD comCad = new ComunidadCAD(session);
            ComunidadCEN comCEN = new ComunidadCEN(comCad);
            IList<ComunidadEN> lista = comCEN.ReadAll(0, 5);

            IEnumerable<ComunidadViewModel> listViewModel = (IEnumerable<ComunidadViewModel>)new ComunidadAssembler().ConvertListENTModel(lista).ToList();

            JuegoCP juegoCP = new JuegoCP();
            if (Session["Usuario"] != null)
            {
                IList<JuegoEN> juegosRecomendados = juegoCP.RecomendarJuego(((UsuarioEN)Session["Usuario"]).Id);
                if (juegosRecomendados.Count() > 0)
                {
                    ViewData["JuegosRecomendados"] = juegosRecomendados;
                }
            }
            
            SessionClose();

            return View(listViewModel);
        }

        public ActionResult Error(HandleErrorInfo error)
        {
            return View(error);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sobre Go-Gaming";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nuestra página de contacto";

            return View();
        }
    }
}