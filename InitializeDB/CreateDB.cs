
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;

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

                Console.WriteLine("Introducimos usuarios a la bbdd...");
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.New_("Kaese", "Sergio", "Miedes", "kaeseks@gmail.com", 666666666, "C/carton", "fotoejemplo", "1234", false);
                usuarioCEN.New_("FroggyChair", "Candela", "Urh", "princesita23@gmail.com", 666999666, "C/cartulina", "fotoejemplo2", "1234", false);
                usuarioCEN.New_("Jaxtified", "Carlos", "Izquierdo", "carlosesetio@gmail.com", 666999888, "C/carta", "fotoejemplo3", "1234", false);
                usuarioCEN.New_("Akapvto", "Jorge", "Reig", "akayamiakuma@gmail.com", 666222888, "C/cartones", "fotoejemplo4", "1234", false);
                usuarioCEN.New_("Sariwii", "Sara", "Morote", "sariwicondosies@gmail.com", 666999222, "C/cartulinas", "fotoejemplo5", "1234", false);

                Console.WriteLine("Introducimos los generos a laa bbdd...");
                GeneroCEN generoCEN = new GeneroCEN();
                generoCEN.New_("Coches");
                generoCEN.New_("Accion");
                generoCEN.New_("Aventuras");
                generoCEN.New_("Metroidvania");
                generoCEN.New_("Estrategia");
                generoCEN.New_("Autochess");
                generoCEN.New_("Terror");
                generoCEN.New_("Roguelike");
                generoCEN.New_("Soulslike");
                generoCEN.New_("FirstPersonShooter");

                Console.WriteLine("Introducimos juegos a la bbdd...");
                JuegoCEN juegoCEN = new JuegoCEN();
                string[] aux_rocket = { "Coches", "Accion" };
                IList<string> generos = aux_rocket;
                juegoCEN.New_("Rocket League", "Juego de coches y futbol", "portada_rocket_league", generos);
                string[] aux_silksong = { "Aventuras", "Accion", "Metroidvania" };
                generos = aux_silksong;
                juegoCEN.New_("Hollow Knight: Silksong", "Solo existe en esta bbdd", "portada_silksong", generos);
                string[] aux_tft = { "Estrategia", "Autochess"};
                generos = aux_tft;
                juegoCEN.New_("League of Legends: TFT", "Solo apto para gente inteligente", "portada_tft", generos);

                Console.WriteLine("Introducimos comunidades a la bbdd...");
                ComunidadCEN comunidadCEN = new ComunidadCEN();
                




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
