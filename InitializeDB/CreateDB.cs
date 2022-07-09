
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
                int sergio = usuarioCEN.New_ ("Kaese", "Sergio", "Miedes", "smg163@alu.ua.es", 666666666, "C/Machamp", "sergio.jpg", "1234", true);
                int candela = usuarioCEN.New_ ("FroggyChair", "Candela", "Urh", "curh1@alu.ua.es", 666999666, "C/Coosto", "candela.jpg", "1234", true);
                int carlos = usuarioCEN.New_ ("Jaxtified", "Carlos", "Izquierdo", "cil4@alu.ua.es", 666999888, "C/Orden sin contacto", "carlos.jpg", "1234", true);
                int jorge = usuarioCEN.New_ ("Akapvto", "Jorge", "Reig", "jrv37@alu.ua.es", 666222888, "C/Equipo Cereza", "jorge.jpg", "1234", true);
                int sara = usuarioCEN.New_ ("Sariwii", "Sara", "Morote", "smb86@alu.ua.es", 666999222, "C/Alameda de Jijon", "sara.jpg", "1234", true);
                int juanmi = usuarioCEN.New_ ("JuanMi", "Juan Miguel", "Lopez", "jmll2@alu.ua.es", 666999667, "C/Caronte", "juanmi.jpg", "1234", false);
                int ruben = usuarioCEN.New_ ("Rubi", "Ruben", "Castillo", "rcp103@alu.ua.es", 666999664, "C/Calderon de la barca", "usuario.png", "1234", false);
                int estela = usuarioCEN.New_ ("Estelar_xX", "Estela", "Martinez", "emd149@alu.ua.es", 666999644, "C/Melocoton", "usuario.png", "1234", false);

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
                int genE = generoCEN.New_ ("Simulacion");
                int genF = generoCEN.New_ ("RPG");
                int genG = generoCEN.New_ ("Carreras");
                int genH = generoCEN.New_ ("MOBA");

                Console.WriteLine ("Introducimos juegos a la bbdd...");
                JuegoCEN juegoCEN = new JuegoCEN ();
                int juego1 = juegoCEN.New_ ("Rocket League", "¡Te damos la bienvenida a este hibrido de alta potencia que mezcla futbol de estilo arcade y vehiculos caoticos!", "/Images/rocket.jpg", new List<int>() {
                                gen1, gen2
                        });
                int juego2 = juegoCEN.New_ ("Hollow Knight", "Hollow Knight cuenta la historia del Caballero, en su busqueda por descubrir los secretos del largamente abandonado reino de los insectos de Hallownest, cuyas profundidades atraen a los aventureros y valientes con la promesa de tesoros o la respuesta a misterios antiguos...", "/Images/hollow.jpg", new List<int>() {
                                gen3, gen2, gen4
                        });
                int juego3 = juegoCEN.New_ ("Teamfight Tactics", "Teamfight Tactics mezcla las adictivas mecanicas del autochess con los carismaticos personajes de Runeterra.", "/Images/portada_tft.jpeg", new List<int>() {
                                gen5, gen6
                        });
                int juego4 = juegoCEN.New_ ("Dark Souls 3", "Dark Souls 3 es el final de la saga y presenta un mundo, el Reino de Lothric, al borde del Apocalipsis por culpa de 'la maldicion de los no muertos', y la razon por la que el mundo aun no se ha sumido en la oscuridad totalmente es el sacrificio que muchos heroes e incluso dioses hicieron al reavivar la llama original, la cual se encarga de mantener la 'Era del fuego', dejando que esta consumiera sus respectivas almas y cuerpos.", "/Images/darksouls3.jpg", new List<int>() {
                                genF, gen9, gen2
                        });
                int juego5 = juegoCEN.New_ ("HearthsStone", "Te damos la bienvenida a Hearthstone, un juego de cartas de estrategia facil de aprender pero salvajemente entretenido.", "/Images/hearthstone.jpg", new List<int>() {
                                gen5, genB
                        });
                int juego6 = juegoCEN.New_ ("Valorant", "Shooter tactico en primera persona 5v5 basado en personajes, en el que importan tanto el dominio de las armas como la habilidad con los Agentes.", "/Images/valorant.jpg", new List<int>() {
                                gen2, genA
                        });
                int juego7 = juegoCEN.New_ ("Team Sonic Racing", "Encarna a Sonic y sus amigos en este juego de carreras en el que tendras que formar equipos de 3 para ganar a tus oponentes.", "/Images/sonicteamracing.jpg", new List<int>() {
                                genG, gen1
                        });
                int juego8 = juegoCEN.New_ ("League of Legends", "League of Legends es un juego en equipo con mas de 140 campeones con los que realizar jugadas epicas.", "/Images/leagueoflegends.jpg", new List<int>() {
                                genH, gen2
                        });

                Console.WriteLine ("Introducimos comunidades a la bbdd...");
                ComunidadCEN comunidadCEN = new ComunidadCEN ();
                int com_rl = comunidadCEN.New_ ("Rocket League", "Comunidad de Rocket League. ¡Calienten motores!", new DateTime (2022, 1, 1), juego1);
                int com_hk = comunidadCEN.New_ ("Hollow Knight", "Comunidad del Hollow Knight. ¡Preparen las pelucas!", new DateTime (2019, 11, 15), juego2);
                int com_lol = comunidadCEN.New_ ("League of Legends", "Comunidad del LoL. Acceso denegado a jugadores de Vayne top.", new DateTime (2018, 12, 3), juego8);

                Console.WriteLine ("Introducimos postst a la bbdd...");
                PostCP postCP = new PostCP ();
                int post1 = postCP.New_ ("Ultimamente he estado jugando mucho, estoy en diamante 3 y mi nickname es KaeseOrigin.", sergio, com_rl, Categoria_PostEnum.otros, "Busco gente para jugar", "", new DateTime (2022, 01, 27, 15, 59, 00)).Id;
                int post2 = postCP.New_ ("No jugueis con el BMW-200 (octane), la hitbox dista mucho del modelo 3D", candela, com_rl, Categoria_PostEnum.opinion, "Opinion sobre el BMW-200", "bmw.jpg", new DateTime (2021, 02, 28, 17, 36, 00)).Id;
                int post3 = postCP.New_ ("Cuando va a salir el SilkSong. ¿Alguien lo sabe? ¿Se ha filtrado?", jorge, com_hk, Categoria_PostEnum.otros, "Fecha de lanzamiento Silksong(?)", "", new DateTime (2021, 11, 10, 23, 06, 00)).Id;
                int post4 = postCP.New_ ("¿Os habeis fijado en que la ulti de Fizz no deja restos de los campeones enemigos cuando son pequeños? Me paso jugando contra un Amumu", sergio, com_lol, Categoria_PostEnum.easterEgg, "Pasiva oculta de Fizz", "ultifizz.jpg", new DateTime (2022, 10, 2, 11, 04, 00)).Id;
                int post5 = postCP.New_ ("Ya ha salido el nuevo parche 20.22. Tercer parche consecutivo que nerfean a Aphelios.", jorge, com_lol, Categoria_PostEnum.noticia, "Parche 20.22", "", new DateTime (2022, 3, 3, 11, 45, 00)).Id;
                int post6 = postCP.New_ ("Me gusta mucho este escenario porque los recargadores de nitro contrastan mejor y se aprecian mejor las distancias. ¿Vosotros que pensais?", carlos, com_rl, Categoria_PostEnum.opinion, "Mi opinion sobre el mapa de Sunrise Field", "", new DateTime (2021, 11, 10, 23, 06, 00)).Id;
                int post7 = postCP.New_ ("He vuelto a sacarme el platino. Y me he pasado el juego en poco mas de 2 horas. Podia haber sido menos si no me hubiesen costado tanto las mantis.", jorge, com_hk, Categoria_PostEnum.noticia, "Otra vez que me saco el platino", "", new DateTime (2022, 5, 2, 11, 35, 00)).Id;
                int post8 = postCP.New_ ("Mi campeon favorito es Anivia. No tendra mucho ataque, no tendra mucha defensa, pero Anivia, la criofenix es uno de los campeones que mas te premia por jugarlo bien.", ruben, com_lol, Categoria_PostEnum.opinion, "Por que me gusta tanto Anivia", "anivia.jpg", new DateTime (2022, 6, 12, 09, 22, 00)).Id;


                Console.WriteLine ("Introducimos comentarios a la bbdd...");
                ComentarioCEN comentarioCEN = new ComentarioCEN ();
                int comentario1 = comentarioCEN.NewRaiz ("Yo puedo jugar contigo, te agrego", candela, post1, DateTime.Now);
                int comentario2 = comentarioCEN.NewRaiz ("No va a salir. Deja de hacerte ilusiones en cada Nintendo Direct.", carlos, post3, DateTime.Now);
                int comentario3 = comentarioCEN.NewRaiz ("Anivia no esta mal, pero me fastidia mucho como Rengar player que soy porque el huevo me impide burstearla", sergio, post8, DateTime.Now);
                int comentario4 = comentarioCEN.NewRaiz ("Me encanta Anivia, pero la ulti es un poco debil para el meta actual", sara, post8, DateTime.Now);
                int comentario5 = comentarioCEN.NewRaiz ("Uno de los mejores escenarios sin duda", ruben, post6, DateTime.Now);
                int comentario6 = comentarioCEN.NewRaiz ("¿Enserio? En ese caso practicare mis vuelos en ese mapa", candela, post6, DateTime.Now);
                int comentario7 = comentarioCEN.NewRaiz ("Y menos mal porque se juega en todas las partidas", sergio, post5, DateTime.Now);
                int comentario8 = comentarioCEN.NewRaiz ("Pues ya me diras como lo haces porque yo no bajo de las 4 horas", estela, post7, DateTime.Now);
                ComentarioCP comentarioCP = new ComentarioCP ();
                int comentario2_1 = comentarioCP.NewHijo ("Nunca va a salir.", jorge, post3, DateTime.Now, comentario2).Id;
                int comentario2_1_1 = comentarioCP.NewHijo ("Yo creo que si que puede salir este anio.", carlos, post3, DateTime.Now, comentario2_1).Id;
                int comentario2_2 = comentarioCP.NewHijo ("Callate, algunos seguimos teniendo la esperanza", jorge, post3, DateTime.Now, comentario2).Id;
                int comentario4_1 = comentarioCP.NewHijo ("Es cierto que algunas mejoras le vendrian muy bien", carlos, post8, DateTime.Now, comentario3).Id;
                int comentario4_1_1 = comentarioCP.NewHijo ("¿Tu como te la buildeas?", sara, post8, DateTime.Now, comentario4_1).Id;
                int comentario8_1 = comentarioCP.NewHijo ("El truco esta en saltarte el powerup del soble salto, no es necesario y lleva mucho tiempo conseguirlo", jorge, post7, DateTime.Now, comentario8).Id;
                int comentario8_1_1 = comentarioCP.NewHijo ("Ahh, eso tiene mucho sentido. He estado haciendolo mal todo este tiempo", estela, post7, DateTime.Now, comentario8_1).Id;
                int comentario8_1_2 = comentarioCP.NewHijo ("Yo lo he hecho en el mismo tiempo con el doble salto. Hay otra ruta, solo tienes que esquivar a los guardianes", carlos, post7, DateTime.Now, comentario8_1).Id;
                int comentario6_1 = comentarioCP.NewHijo ("Lo malo es que es un poco mas bajo y no puedes volar tanto", sergio, post6, DateTime.Now, comentario6).Id;


                Console.WriteLine ("Introducimos avisos a la bbdd...");
                AvisoCP avisoCP = new AvisoCP ();
                avisoCP.New_ ("Insultaste y/u ofendiste a un companiero.", sara, new DateTime (2020, 12, 31, 23, 06, 00));
                avisoCP.New_ ("Infringiste las normas de la comunidad de Hollow Kight.", estela, new DateTime (2020, 12, 31, 23, 06, 00));
                avisoCP.New_ ("Insultaste y/u ofendiste a un companiero.", estela, new DateTime (2020, 10, 14, 12, 50, 00));
                avisoCP.New_ ("Insultaste y/u ofendiste a un companiero.", estela, new DateTime (2020, 8, 22, 14, 10, 00));

                Console.WriteLine ("Metemos a un usuario en una comunidad:\n");
                comunidadCEN.AddUsuarios (com_hk, new List<int>(){
                                jorge, carlos, juanmi, estela
                        });
                Console.WriteLine ("Jorge y Carlos han entrado en la comunidad de Silksong");
                comunidadCEN.AddUsuarios (com_rl, new List<int>(){
                                sergio, candela, carlos, juanmi
                        });
                comunidadCEN.AddUsuarios (com_lol, new List<int>(){
                                sergio, candela, carlos, juanmi, jorge, sara
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

                Console.WriteLine ("Otros usuarios le dan like a otros posts...");
                usuarioCP.InteractPost (sergio, post6);
                usuarioCP.InteractPost (candela, post6);
                usuarioCP.InteractPost (juanmi, post6);
                usuarioCP.InteractPost (estela, post8);
                usuarioCP.InteractPost (carlos, post8);
                usuarioCP.InteractPost (sergio, post8);
                usuarioCP.InteractPost (jorge, post8);
                usuarioCP.InteractPost (sara, post8);
                usuarioCP.InteractPost (estela, post8);
                usuarioCP.InteractPost (carlos, post3);
                usuarioCP.InteractPost (juanmi, post3);
                usuarioCP.InteractPost (carlos, post7);
                usuarioCP.InteractPost (sergio, post5);
                usuarioCP.InteractPost (candela, post5);
                usuarioCP.InteractPost (carlos, post5);
                usuarioCP.InteractPost (juanmi, post5);
                usuarioCP.InteractPost (jorge, post5);
                usuarioCP.InteractPost (sara, post5);


                Console.WriteLine ("\nFiltramos los posts por categoria opinion:");
                PostCEN postCEN = new PostCEN ();
                IList<PostEN> posts = postCEN.GetPostPorCategoria (Categoria_PostEnum.opinion);
                foreach (PostEN post in posts) {
                        Console.WriteLine ("ID-> " + post.Id + ", Categoria-> " + post.Categoria + ", Fecha/Hora-> " + post.Hora);
                }
                Console.WriteLine ("\n");

                Console.WriteLine ("Intentamos banear a un usuario:");
                usuarioCP.BanearUsuario (candela);

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

                Console.WriteLine ("Usuario Candela sigue a otros usuarios:");
                int[] followers = { sergio, carlos, sara, juanmi };
                IList<int> followersList = followers;
                usuarioCEN.AddFollowing (candela, followersList);
                usuarioCEN.AddFollowing (carlos, new List<int>() {
                                sergio, jorge, estela
                        });
                usuarioCEN.AddFollowing (sergio, new List<int>() {
                                carlos, estela, juanmi
                        });
                usuarioCEN.AddFollowing (estela, new List<int>() {
                                candela, ruben, juanmi
                        });
                usuarioCEN.AddFollowing (jorge, new List<int>() {
                                sergio, estela, juanmi, carlos, ruben, sara, candela
                        });
                usuarioCEN.AddFollowing (ruben, new List<int>() {
                                sergio, carlos
                        });
                usuarioCEN.AddFollowing (sara, new List<int>() {
                                sergio, juanmi
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
                int not4 = notificacionCP.New_ (post4).Id;
                int not5 = notificacionCP.New_ (post5).Id;
                int not6 = notificacionCP.New_ (post6).Id;
                int not7 = notificacionCP.New_ (post7).Id;
                int not8 = notificacionCP.New_ (post8).Id;


                //Console.WriteLine ("\nYa va siendo hora de mandar las notificaciones...");
                //notificacionCP.EnviarNotificacion (not1);
                //notificacionCP.EnviarNotificacion (not2);
                //notificacionCP.EnviarNotificacion (not3);
                //notificacionCP.EnviarNotificacion(not4);
                //notificacionCP.EnviarNotificacion(not5);
                //notificacionCP.EnviarNotificacion(not6);
                //notificacionCP.EnviarNotificacion(not7);
                //notificacionCP.EnviarNotificacion(not8);


                Console.WriteLine ("\nFiltramos entre todos los juegos por el nombre League:");
                IList<JuegoEN> juegos = juegoCEN.Busqueda ("League");
                foreach (JuegoEN juego in juegos) {
                        Console.WriteLine (juego.Nombre);
                }
                Console.WriteLine ("\n");

                Console.WriteLine ("\nAgregamos juegos a los Usuarios...");
                usuarioCEN.AddJuego (sergio, new List<int>() {
                                juego1, juego2, juego5
                        });
                usuarioCEN.AddJuego (candela, new List<int>() {
                                juego4, juego6, juego7
                        });
                usuarioCEN.AddJuego (carlos, new List<int>() {
                                juego1, juego2, juego3, juego4, juego5, juego6, juego7, juego8
                        });
                usuarioCEN.AddJuego (jorge, new List<int>() {
                                juego4, juego2, juego5, juego8
                        });
                usuarioCEN.AddJuego (ruben, new List<int>() {
                                juego2, juego7
                        });
                usuarioCEN.AddJuego (sara, new List<int>() {
                                juego4, juego6
                        });
                usuarioCEN.AddJuego (juanmi, new List<int>() {
                                juego3, juego2, juego8
                        });
                usuarioCEN.AddJuego (estela, new List<int>() {
                                juego4, juego1, juego3
                        });
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
