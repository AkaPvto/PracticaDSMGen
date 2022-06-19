
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.Enumerated.DSMPracticas;
using PracticaDSMGenNHibernate.CP.DSMPracticas;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                Console.WriteLine ("Introducimos usuarios a la bbdd...");
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                int sergio = usuarioCEN.New_ ("Kaese", "Sergio", "Miedes", "kaeseks@gmail.com", 666666666, "C/carton", "fotoejemplo", "1234", false);
                int candela = usuarioCEN.New_ ("FroggyChair", "Candela", "Urh", "princesita23@gmail.com", 666999666, "C/cartulina", "fotoejemplo2", "1234", false);
                int carlos = usuarioCEN.New_ ("Jaxtified", "Carlos", "Izquierdo", "carlosesetio@gmail.com", 666999888, "C/carta", "fotoejemplo3", "1234", false);
                int jorge = usuarioCEN.New_ ("Akapvto", "Jorge", "Reig", "akayamiakuma@gmail.com", 666222888, "C/cartones", "fotoejemplo4", "1234", false);
                int sara = usuarioCEN.New_ ("Sariwii", "Sara", "Morote", "sariwicondosies@gmail.com", 666999222, "C/cartulinas", "fotoejemplo5", "1234", false);

                Console.WriteLine ("Introducimos los generos a laa bbdd...");
                GeneroCEN generoCEN = new GeneroCEN ();
                generoCEN.New_ ("Coches");
                generoCEN.New_ ("Accion");
                generoCEN.New_ ("Aventuras");
                generoCEN.New_ ("Metroidvania");
                generoCEN.New_ ("Estrategia");
                generoCEN.New_ ("Autochess");
                generoCEN.New_ ("Terror");
                generoCEN.New_ ("Roguelike");
                generoCEN.New_ ("Soulslike");
                generoCEN.New_ ("FirstPersonShooter");

                Console.WriteLine ("Introducimos juegos a la bbdd...");
                JuegoCEN juegoCEN = new JuegoCEN ();
                string[] aux_rocket = { "Coches", "Accion" };
                IList<string> generos = aux_rocket;
                juegoCEN.New_ ("Rocket League", "Juego de coches y futbol", "portada_rocket_league", generos);
                string[] aux_silksong = { "Aventuras", "Accion", "Metroidvania" };
                generos = aux_silksong;
                juegoCEN.New_ ("Hollow Knight: Silksong", "Solo existe en esta bbdd", "portada_silksong", generos);
                string[] aux_tft = { "Estrategia", "Autochess" };
                generos = aux_tft;
                juegoCEN.New_ ("League of Legends: TFT", "Solo apto para gente inteligente", "portada_tft", generos);

                Console.WriteLine ("Introducimos comunidades a la bbdd...");
                ComunidadCEN comunidadCEN = new ComunidadCEN ();
                string com_rl = comunidadCEN.New_ ("Rocket League", "Comunidad de Rocket League. Calienten motores!", new DateTime (2022, 1, 1), "Rocket League");
                string com_hks = comunidadCEN.New_ ("Silksong", "Comunidad del Silksong. Preparen las pelucas, SIUUUUU!", new DateTime (2019, 11, 15), "Hollow Knight: Silksong");

                Console.WriteLine ("Introducimos postst a la bbdd...");
                PostCEN postCEN = new PostCEN ();
                int post1 = postCEN.New_ ("Ultimamente he estado jugando mucho, estoy en diamante 3 y mi nickname es KaeseOrigin.", sergio, com_rl, Categoria_PostEnum.blanco, "Busco gente para jugar", "", DateTime.Parse ("3/1/2022"), DateTime.Parse ("16:00:00"));
                int post2 = postCEN.New_ ("No jugueis con el BMW-200 (octane), la hitbox dista mucho del modelo 3D", candela, com_rl, Categoria_PostEnum.opinion, "Opinion sobre el BMW-200", "", DateTime.Parse ("5/1/2022"), DateTime.Parse ("11:23:00"));
                int post3 = postCEN.New_ ("Cuando va a salir el jueguito. Alguien lo sabe?. Se ha filtrado?", jorge, com_hks, Categoria_PostEnum.blanco, "Fecha de lanzamiento(?)", "", DateTime.Parse ("14/4/2020"), DateTime.Parse ("03:27:00"));

                Console.WriteLine ("Introducimos comentarios a la bbdd...");
                ComentarioCEN comentarioCEN = new ComentarioCEN ();
                comentarioCEN.NewRaiz("Yo puedo jugar contigo",candela, post1, DateTime.Parse("3/1/2022"), DateTime.Parse("17:45:00"), 0);
                comentarioCEN.NewRaiz("Nunca va a salir. Deja de hacerte ilusiones en cada Nintendo Direct.", carlos, post3, DateTime.Parse("17/5/2020"), DateTime.Parse("13:11:00"), 0);

                Console.WriteLine("Introducimos notificaciones a la bbdd...");
                NotificacionCEN notificacionCEN = new NotificacionCEN();
                //notificacionCEN.New_("Se ha subido un nuevo post a la comunidad de Rocket League. No te lo pierdas!", com_rl, post1);
                //notificacionCEN.New_("Se ha subido un nuevo post a la comunidad de SilkSong. No te lo pierdas!", com_hks, post3);

                Console.WriteLine("Introducimos avisos a la bbdd...");
                AvisoCEN avisoCEN = new AvisoCEN();
                avisoCEN.New_("Insultaste y/u ofendiste a un compa�ero.", sara, DateTime.Parse("7/12/2021"), DateTime.Parse("02:39:00"));

                Console.WriteLine("\nFiltramos los posts por categoria opinion:");
                IList<PostEN> posts = postCEN.GetPostPorCategoria(Categoria_PostEnum.opinion);
                foreach (PostEN post in posts){
                    Console.WriteLine("ID-> " + post.Id + ", Categor�a-> " + post.Categoria);
                }
                Console.WriteLine("\n");

                Console.WriteLine("Intentamos banear a un usuario:");
                usuarioCEN.BanearUsuario(candela);

                Console.WriteLine("Recuperamos los comentarios ordenados por fecha:");
                IList<ComentarioEN> comentarios = comentarioCEN.GetComentariosFecha();
                foreach (ComentarioEN comentario in comentarios){
                    Console.WriteLine("ID-> " + comentario.Id + ", Fecha-> " + comentario.Fecha);
                }
                Console.WriteLine("\n");

                Console.WriteLine("Usuario Candela sigue a otros usuarios (Carlos, Sergio y Sara):");
                UsuarioCP usuarioCP = new UsuarioCP();
                int[] emails = { carlos, sergio, sara };
                IList<int> oids = emails;
                usuarioCP.AddFollowing(candela, oids);
                /*PROTECTED REGION END*/
            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
