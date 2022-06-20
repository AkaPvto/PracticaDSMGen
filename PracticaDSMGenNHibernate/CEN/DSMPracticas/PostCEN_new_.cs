
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.Exceptions;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;


/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CEN.DSMPracticas_Post_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
public partial class PostCEN
{
public int New_ (string p_contenido, int p_usuarioCreador, string p_comunidad, PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum p_categoria, string p_titulo, string p_imagen, Nullable<DateTime> p_hora)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Post_new__customized) START*/

        PostEN postEN = null;

        int oid;

        //Initialized PostEN
        postEN = new PostEN ();
        postEN.Contenido = p_contenido;


        if (p_usuarioCreador != -1) {
                postEN.UsuarioCreador = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                postEN.UsuarioCreador.Id = p_usuarioCreador;
        }


        if (p_comunidad != null) {
                postEN.Comunidad = new PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN ();
                postEN.Comunidad.Nombre = p_comunidad;
        }

        postEN.Categoria = p_categoria;

        postEN.Titulo = p_titulo;

        postEN.Imagen = p_imagen;

        postEN.Hora = p_hora;

        //Call to PostCAD

        oid = _IPostCAD.New_ (postEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
