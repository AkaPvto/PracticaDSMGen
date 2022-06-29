using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGaming.Controllers;
using GoGaming.Models;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace GoGaming.Assemblers
{
    public class JuegoAssembler : BasicController
    {
        public JuegoViewModel ConvertENToModelUI(JuegoEN juegoEN)
        {
            SessionInitialize();
            GeneroCAD generoCAD = new GeneroCAD(session);
            GeneroCEN generoCEN = new GeneroCEN(generoCAD);
            IList<GeneroEN> listaGens = generoCEN.ReadAll(0, -1);
            List<bool> listaGensVM = new List<bool>();

            for (int i = 0; i < listaGens.Count(); i++)
            {
                if (generoCEN.GetGenerosJuego(juegoEN.Id).Contains(listaGens[i]))
                {
                    listaGensVM.Add(true);
                }
                else
                {
                    listaGensVM.Add(false);
                }
                
            }

            JuegoViewModel juegoVM = new JuegoViewModel();
            juegoVM.Id = juegoEN.Id;
            juegoVM.Nombre = juegoEN.Nombre;
            juegoVM.Descripcion = juegoEN.Descripcion;
            juegoVM.Portada = juegoEN.Portada;
            juegoVM.Generos = listaGensVM;
            
            return juegoVM;
        }

        public IList<JuegoViewModel> ConvertListENToModel(IList<JuegoEN> listEN)
        {
            IList<JuegoViewModel> listVM = new List<JuegoViewModel>();
            foreach(JuegoEN juego in listEN)
            {
                listVM.Add(ConvertENToModelUI(juego));
            }
            return listVM;
        }
    }
}