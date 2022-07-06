using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoGaming.Assemblers;
using GoGaming.Models;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace GoGaming.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            IList<UsuarioEN> listEN = usuCEN.ReadAll(0, -1);
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        public ActionResult Seguidores(int id)
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            IList<UsuarioEN> listEN = usuCEN.GetFollowing(id);
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        public ActionResult Seguidos(int id)
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            IList<UsuarioEN> listEN = usuCEN.GetFollowed(id);
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = new UsuarioCEN().ReadOID(id);
            int seguidores = new UsuarioCEN().GetFollowing(id).Count;
            int seguidos = new UsuarioCEN().GetFollowed(id).Count;
            UsuarioViewModel usuarioVM = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

            ViewData["seguidores"] = seguidores;
            ViewData["seguidos"] = seguidos;

            IList<UsuarioEN> listEN = usuarioCEN.GetFollowed(((UsuarioEN)Session["Usuario"]).Id);
            IList<int> idUsuariosSeguidos = new List<int>();
            foreach (UsuarioEN usuario in listEN)
            {
                idUsuariosSeguidos.Add(usuario.Id);
            }
            bool siguiendo = idUsuariosSeguidos.Contains(id);
            ViewData["Siguiendo"] = siguiendo;
            return View(usuarioVM);
        }

        // POST: Usuario/Details/5
        public ActionResult Seguir(int idFollower, int idFollowed)
        {
            try
            {
                // TODO: Add delete logic here
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                IList<UsuarioEN> listEN = usuarioCEN.GetFollowing(idFollowed);
                IList<int> idUsuariosSeguidos = new List<int>();
                foreach (UsuarioEN usuario in listEN)
                {
                    idUsuariosSeguidos.Add(usuario.Id);
                }
                bool siguiendo = idUsuariosSeguidos.Contains(idFollower);

                if (siguiendo)
                {
                    usuarioCEN.DeleteFollowing(idFollowed, new List<int>() { idFollower });
                }
                else
                {
                    usuarioCEN.AddFollowing(idFollowed, new List<int>() { idFollower });
                }
                return RedirectToAction("Details/"+idFollowed);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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

       

        public ActionResult Login()
        {
            UsuarioViewModel usuarioVM = new UsuarioViewModel();
            usuarioVM.Apellidos = "";
            usuarioVM.Direccion = "";
            usuarioVM.Email = "";
            usuarioVM.Foto = "";
            usuarioVM.Nickname = "";
            usuarioVM.Nombre = "";
            usuarioVM.Password = "";
            return View(usuarioVM);
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel usuario)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            int idUsuario = usuarioCEN.GetUsuarioEmail(usuario.Email).Id;
            string loginResult = usuarioCEN.Login(idUsuario, usuario.Password);

            if(loginResult != null)
            {
                Session["Usuario"] = usuarioCEN.ReadOID(idUsuario);
                return RedirectToAction("../");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return RedirectToAction("../");
        }
    }
}
