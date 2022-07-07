
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
                int sergio = usuarioCEN.New_ ("Kaese", "Sergio", "Miedes", "smg163@alu.ua.es", 666666666, "C/Machamp", "usuario.png", "1234");
                int candela = usuarioCEN.New_ ("FroggyChair", "Candela", "Urh", "curh1@alu.ua.es", 666999666, "C/Coosto", "usuario.png", "1234");
                int carlos = usuarioCEN.New_ ("Jaxtified", "Carlos", "Izquierdo", "cil4@alu.ua.es", 666999888, "C/Orden sin contacto", "usuario.png", "1234");
                int jorge = usuarioCEN.New_ ("Akapvto", "Jorge", "Reig", "jrv37@alu.ua.es", 666222888, "C/Equipo Cereza", "usuario.png", "1234");
                int sara = usuarioCEN.New_ ("Sariwii", "Sara", "Morote", "smb86@alu.ua.es", 666999222, "C/Alameda de Jijón", "usuario.png", "1234");
                int juanmi = usuarioCEN.New_("JuanMi", "Juan Miguel", "López", "jmll2@alu.ua.es", 666999667, "C/Caronte", "usuario.png", "1234");
                int ruben = usuarioCEN.New_("Rubi", "Rubén", "Castillo", "rcp103@alu.ua.es", 666999664, "C/Calderón de la barca", "usuario.png", "1234");
                int estela = usuarioCEN.New_("Estelar_xX", "Estela", "Martínez", "emd149@alu.ua.es", 666999644, "C/Melocotón", "usuario.png", "1234");

                Console.WriteLine ("Introducimos los generos a laa bbdd...");
                GeneroCEN generoCEN = new GeneroCEN ();
                int gen1 = generoCEN.New_ ("Coches");
                int gen2 = generoCEN.New_ ("Accion");
                int gen3 = generoCEN.New_ ("Aventuras");
                int gen4 = generoCEN.New_ ("Metroidvania");
                int gen5 = generoCEN.New_ ("Estrategia");
                int gen6 = generoCEN.New_ ("Autochess");
                int gen7 = generoCEN.New_ ("Terror");
                int gen8 = generoCEN.New_ ("Roguelike");
                int gen9 = generoCEN.New_ ("Soulslike");
                int genA = generoCEN.New_ ("FirstPersonShooter");
                int genB = generoCEN.New_ ("Cartas");
                int genC = generoCEN.New_ ("Trivia");
                int genD = generoCEN.New_ ("Deportes");
                int genE = generoCEN.New_ ("Simulación");

                Console.WriteLine ("Introducimos juegos a la bbdd...");
                JuegoCEN juegoCEN = new JuegoCEN ();
                int juego1 = juegoCEN.New_ ("Rocket League", "¡Te damos la bienvenida a este híbrido de alta potencia que mezcla fútbol de estilo arcade y vehículos caóticos!", "/Images/rocket.jpg", new List<int>() { gen1, gen2 });
                int juego2 = juegoCEN.New_ ("Hollow Knight", "Hollow Knight cuenta la historia del Caballero, en su búsqueda por descubrir los secretos del largamente abandonado reino de los insectos de Hallownest, cuyas profundidades atraen a los aventureros y valientes con la promesa de tesoros o la respuesta a misterios antiguos...", "/Images/hollow.jpg", new List<int>() { gen3, gen2, gen4 });
                int juego3 = juegoCEN.New_ ("Teamfight Tactics", "Teamfight Tactics mezcla las adictivas mecánicas del autochess con los carismáticos personajes de Runeterra.", "/Images/portada_tft.jpeg", new List<int>() { gen5, gen6 });

                Console.WriteLine ("Introducimos comunidades a la bbdd...");
                ComunidadCEN comunidadCEN = new ComunidadCEN ();
                int com_rl = comunidadCEN.New_ ("Rocket League", "Comunidad de Rocket League. Calienten motores!", new DateTime (2022, 1, 1), juego1);
                int com_hks = comunidadCEN.New_ ("Silksong", "Comunidad del Silksong. Preparen las pelucas, SIUUUUU!", new DateTime (2019, 11, 15), juego2);

                Console.WriteLine ("Introducimos postst a la bbdd...");
                PostCP postCP = new PostCP ();
                int post1 = postCP.New_ ("Ultimamente he estado jugando mucho, estoy en diamante 3 y mi nickname es KaeseOrigin.", sergio, com_rl, Categoria_PostEnum.blanco, "Busco gente para jugar", "", new DateTime (2022, 01, 27, 15, 59, 00)).Id;
                int post2 = postCP.New_ ("No jugueis con el BMW-200 (octane), la hitbox dista mucho del modelo 3D", candela, com_rl, Categoria_PostEnum.opinion, "Opinion sobre el BMW-200", "bmw.jpg", new DateTime (2021, 02, 28, 17, 36, 00)).Id;
                int post3 = postCP.New_ ("Cuando va a salir el jueguito. Alguien lo sabe?. Se ha filtrado?", jorge, com_hks, Categoria_PostEnum.blanco, "Fecha de lanzamiento(?)", "", new DateTime (2021, 11, 10, 23, 06, 00)).Id;


                Console.WriteLine ("Introducimos comentarios a la bbdd...");
                ComentarioCEN comentarioCEN = new ComentarioCEN ();
                int comentario1 = comentarioCEN.NewRaiz ("Yo puedo jugar contigo", candela, post1, DateTime.Now);
                int comentario2 = comentarioCEN.NewRaiz ("No va a salir. Deja de hacerte ilusiones en cada Nintendo Direct.", carlos, post3, DateTime.Now);
                ComentarioCP comentarioCP = new ComentarioCP ();
                int comentario2_1 = comentarioCP.NewHijo ("Nunca va a salir. ", jorge, post3, DateTime.Now, comentario2).Id;
                int comentario2_1_1 = comentarioCP.NewHijo ("Yo creo que si que puede salir este anio. ", carlos, post3, DateTime.Now, comentario2_1).Id;
                int comentario2_2 = comentarioCP.NewHijo ("Callate, algunos seguimos teniendo la esperanza", jorge, post3, DateTime.Now, comentario2).Id;


                Console.WriteLine ("Introducimos avisos a la bbdd...");
                AvisoCEN avisoCEN = new AvisoCEN ();
                avisoCEN.New_ ("Insultaste y/u ofendiste a un companiero.", sara, new DateTime (2020, 12, 31, 23, 06, 00));

                Console.WriteLine ("Metemos a un usuario en una comunidad:\n");
                comunidadCEN.AddUsuarios (com_hks, new List<int>(){
                                jorge, carlos
                        });
                Console.WriteLine ("Jorge y Carlos han entrado en la comunidad de Silksong");
                comunidadCEN.AddUsuarios (com_rl, new List<int>(){
                                sergio, candela
                        });
                Console.WriteLine ("Sergio ha entrado en la comunidad de Rocket League");

                Console.WriteLine ("\nSe va a probar los likes de un post: ");
                UsuarioCP usuarioCP = new UsuarioCP ();
                Console.WriteLine ("Jorge le da like a un post de la comunidad Silksong... ");
                usuarioCP.InteractPost (jorge, post3);
                Console.WriteLine ("Jorge le da like a un post de la comunidad de Rocket League... ");
                usuarioCP.InteractPost (jorge, post2);
                Console.WriteLine ("Jorge le da like a un post al que ya le habia dado like de la comunidad de Silksong");
                usuarioCP.InteractPost (jorge, post3);
                Console.WriteLine ("Sergio le da like a un post de la comunidad de Rocket League");
                usuarioCP.InteractPost (sergio, post2);


                Console.WriteLine ("\nFiltramos los posts por categoria opinion:");
                PostCEN postCEN = new PostCEN ();
                IList<PostEN> posts = postCEN.GetPostPorCategoria (Categoria_PostEnum.opinion);
                foreach (PostEN post in posts) {
                        Console.WriteLine ("ID-> " + post.Id + ", Categoria-> " + post.Categoria + ", Fecha/Hora-> " + post.Hora);
                }
                Console.WriteLine ("\n");

                Console.WriteLine ("Intentamos banear a un usuario:");
                usuarioCEN.BanearUsuario (candela);

                //Console.WriteLine ("\nRecuperamos los comentarios del post1 odenados por likes: ");
                //IList<ComentarioEN> coments = comentarioCEN.GetComentariosLikes (post1);
                //foreach (ComentarioEN com in coments) {
                //        Console.WriteLine (com.Contenido);
                //}
                //Console.WriteLine ("");

                Console.WriteLine ("Recuperamos los comentarios del post1 ordenados por fecha:");
                IList<ComentarioEN> comentarios = comentarioCEN.GetComentariosFecha (post1);
                foreach (ComentarioEN comentario in comentarios) {
                        Console.WriteLine ("ID-> " + comentario.Id + ", Fecha-> " + comentario.Hora);
                }
                Console.WriteLine ("\n");
                ComentarioEN comentarioPrueba = comentarioCEN.ReadOID (comentario2_1);

                Console.WriteLine ("Usuario Candela sigue a otros usuarios (Carlos, Sergio y Sara):");
                int[] followers = { sergio, carlos, sara };
                IList<int> followersList = followers;
                usuarioCEN.AddFollowing (candela, followersList);
                usuarioCEN.AddFollowing (carlos, new List<int>() {
                                sergio, jorge
                        });
                usuarioCEN.AddFollowing (sergio, new List<int>() {
                                candela
                        });

                Console.WriteLine ("El usuario Candela deja de seguir a otro usuario (Carlos):");
                int[] unFollower = { carlos };
                IList<int> unFollowerList = unFollower;
                usuarioCEN.DeleteFollowing (candela, unFollowerList);

                Console.WriteLine ("Introducimos notificaciones a la bbdd...");
                NotificacionCP notificacionCP = new NotificacionCP ();
                int not1 = notificacionCP.New_ (post1).Id;
                int not2 = notificacionCP.New_ (post2).Id;
                int not3 = notificacionCP.New_ (post3).Id;

                Console.WriteLine ("\nYa va siendo hora de mandar las notificaciones...");
                notificacionCP.EnviarNotificacion (not1);
                notificacionCP.EnviarNotificacion (not2);
                notificacionCP.EnviarNotificacion (not3);


                Console.WriteLine ("\nFiltramos entre todos los juegos por el nombre League:");
                IList<JuegoEN> juegos = juegoCEN.Busqueda ("League");
                foreach (JuegoEN juego in juegos) {
                        Console.WriteLine (juego.Nombre);
                }
                Console.WriteLine ("\n");

                Console.WriteLine ("\nAgregamos juegos al usuario Sergio...");
                int[] juegos2 = { juego1, juego2 };
                IList<int> oidsjuegos = juegos2;
                usuarioCEN.AddJuego (sergio, oidsjuegos);
                Console.WriteLine ();

                Console.WriteLine ("\nFiltramos los juegos por el usuario Sergio:");
                juegos = juegoCEN.GetJuegosPorUsuario (sergio);
                foreach (JuegoEN juego in juegos) {
                        Console.WriteLine (juego.Nombre);
                }
                Console.WriteLine ("\n");

                Console.WriteLine ("\nFiltramos por los seguidos de Candela:");
                IList<UsuarioEN> seguidos = usuarioCEN.GetFollowing (candela);
                foreach (UsuarioEN seguido in seguidos) {
                        Console.WriteLine (seguido.Email);
                }

                Console.WriteLine ("\nFiltramos por los seguidos de Carlos:");
                IList<UsuarioEN> seguidosCarlos = usuarioCEN.GetFollowing (carlos);
                foreach (UsuarioEN seguido in seguidosCarlos) {
                        Console.WriteLine (seguido.Email);
                }

                Console.WriteLine ("\nFiltramos por los seguidores de Sergio:");
                IList<UsuarioEN> seguidoresSergio = usuarioCEN.GetFollowed (sergio);
                foreach (UsuarioEN seguido in seguidoresSergio) {
                        Console.WriteLine (seguido.Email);
                }

                Console.WriteLine ("\nRecomendamos juegos al usuario Candela:");
                JuegoCP juegoCP = new JuegoCP ();
                juegoCP.RecomendarJuego (candela);

                Console.WriteLine ("\nAgregamos juegos al usuario Carlos...");
                int[] juegos3 = { juego1, juego3 };
                oidsjuegos = juegos3;
                usuarioCEN.AddJuego (carlos, oidsjuegos);
                Console.WriteLine ();

                Console.WriteLine ("\nEl usuario Candela sigue a Carlos:");
                usuarioCEN.AddFollowing (candela, unFollowerList);

                Console.WriteLine ("\nRecomendamos juegos de nuevo al usuario Candela:");
                juegoCP.RecomendarJuego (candela);

                Console.WriteLine ("\nRecuperamos los posts de la comunidad de Rocket League ordenados por likes: ");
                IList<PostEN> posts2 = postCEN.GetPostComunidadLikes (com_rl);
                foreach (PostEN post in posts2) {
                        Console.WriteLine (post.Contenido);
                }
                Console.WriteLine ("");

                Console.WriteLine ("\nRecuperamos los posts de la comunidad de Rocket League ordenados por fecha: ");
                IList<PostEN> posts3 = postCEN.GetPostComunidadFecha (com_rl);
                foreach (PostEN post in posts3) {
                        Console.WriteLine (post.Contenido);
                }
                Console.WriteLine ("");
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
