using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoGaming.Models;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace GoGaming.Assemblers
{
    public class JuegoAssembler
    {
        public JuegoViewModel ConvertENToModelUI(JuegoEN juegoEN)
        {
            JuegoViewModel juegoVM = new JuegoViewModel();
            juegoVM.Nombre = juegoEN.Nombre;
            juegoVM.Descripcion = juegoEN.Descripcion;
            juegoVM.Portada = juegoEN.Portada;
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