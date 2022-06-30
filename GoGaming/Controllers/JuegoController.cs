﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using NHibernate;
using GoGaming.Models;
using GoGaming.Assemblers;

namespace GoGaming.Controllers
{
    public class JuegoController : BasicController
    {
        // GET: Juego
        public ActionResult Index()
        {
            SessionInitialize();
            JuegoCAD juegoCAD = new JuegoCAD(session);
            JuegoCEN juegoCEN = new JuegoCEN(juegoCAD);

            IList<JuegoEN> listEN = juegoCEN.ReadAll(0, -1);
            IEnumerable<JuegoViewModel> listVM = new JuegoAssembler().ConvertListENToModel(listEN).ToList();

            SessionClose();

            return View(listVM);
        }

        // GET: Juego/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            JuegoCAD juegoCAD = new JuegoCAD(session);
            JuegoCEN juegoCEN = new JuegoCEN(juegoCAD);
            GeneroCAD generoCAD = new GeneroCAD(session);
            GeneroCEN generoCEN = new GeneroCEN(generoCAD);


            IList<GeneroEN> listaGeneros = generoCEN.ReadAll(0, -1);
            List<string> listaNombres = new List<string>();
            foreach (GeneroEN genero in listaGeneros)
            {
                listaNombres.Add(genero.Nombre);
            }
            ViewData["numGeneros"] = listaGeneros.Count();
            ViewData["nombresGenero"] = listaNombres.ToArray();

            JuegoEN juegoEN = juegoCEN.ReadOID(id);
            JuegoViewModel juegoVM = new JuegoAssembler().ConvertENToModelUI(juegoEN);

            

            SessionClose();

            return View(juegoVM);
        }

        // GET: Juego/Create
        public ActionResult Create()
        {
            SessionInitialize();
            GeneroCAD generoCAD = new GeneroCAD(session);
            GeneroCEN generoCEN = new GeneroCEN(generoCAD);


            IList<GeneroEN> listaGeneros = generoCEN.ReadAll(0, -1);
            List<string> listaNombres = new List<string>();
            foreach (GeneroEN genero in listaGeneros)
            {
                listaNombres.Add(genero.Nombre);
            }
            ViewData["numGeneros"] = listaGeneros.Count();
            ViewData["nombresGenero"] = listaNombres.ToArray();
            //JuegoViewModel juegoVM = new JuegoViewModel();
            //juegoVM.Generos = listaCheck;

            SessionClose();
            return View();
        }

        // POST: Juego/Create
        [HttpPost]
        public ActionResult Create(JuegoViewModel juegoVM)
        {
            try
            {
                SessionInitialize();
                GeneroCAD generoCAD = new GeneroCAD(session);
                GeneroCEN generoCEN = new GeneroCEN(generoCAD);
                IList<GeneroEN> listaGeneros = generoCEN.ReadAll(0, -1);
                IList<int> generos = new List<int>();
                for(int i = 0; i<listaGeneros.Count(); i++)
                {
                    if (juegoVM.Generos[i])
                    {
                        generos.Add(listaGeneros[i].Id);
                    }
                }

                JuegoCEN juegoCEN = new JuegoCEN();
                juegoCEN.New_(juegoVM.Nombre, juegoVM.Descripcion, juegoVM.Portada, generos);


                SessionClose();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Juego/Edit/5
        public ActionResult Edit(int id)
        {
            JuegoEN juegoEN = new JuegoCEN().ReadOID(id);
            JuegoViewModel juegoVM = new JuegoAssembler().ConvertENToModelUI(juegoEN);

            return View(juegoVM);
        }

        // POST: Juego/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, JuegoViewModel juegoVM)
        {
            try
            {
                JuegoCEN juegoCEN = new JuegoCEN();
                juegoCEN.Modify(id, juegoVM.Nombre, juegoVM.Descripcion, juegoVM.Portada);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Juego/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            JuegoCAD juegoCAD = new JuegoCAD(session);
            JuegoCEN juegoCEN = new JuegoCEN(juegoCAD);
            GeneroCAD generoCAD = new GeneroCAD(session);
            GeneroCEN generoCEN = new GeneroCEN(generoCAD);


            IList<GeneroEN> listaGeneros = generoCEN.ReadAll(0, -1);
            List<string> listaNombres = new List<string>();
            foreach (GeneroEN genero in listaGeneros)
            {
                listaNombres.Add(genero.Nombre);
            }
            ViewData["numGeneros"] = listaGeneros.Count();
            ViewData["nombresGenero"] = listaNombres.ToArray();

            JuegoEN juegoEN = juegoCEN.ReadOID(id);
            JuegoViewModel juegoVM = new JuegoAssembler().ConvertENToModelUI(juegoEN);



            SessionClose();

            return View(juegoVM);
        }

        // POST: Juego/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                new JuegoCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
