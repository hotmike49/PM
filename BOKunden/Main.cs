/// BOKunden: Businessobjekt zur Applikation PLWebKunden (C# ASP.Net Presentation Layer)
/// Demoapplikation in der LV "Web Programmierung 2"
/// Author: G. Schmiedl, FH St. Pölten
/// 
/// Dieses Projekt realisiert das BO nach dem Domain Model Pattern, wobei das Erzeugen von
/// Objekten nur durch die Verwendung von BO-Methoden erlaubt ist. 
///  cMain: Starterobjekt ist statisch - kann nicht instanziert werden - aber verwendet
///  BOKunde: bekommt man nur mit Hilfe von Methoden in cMain
///  BOKommentar: bekommt man nur von Methoden aus BOKunde

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace BO_PM {
    // Die Klasse Main ist das Starterobjekt dieses Businessobjekts
    // Sie ist statisch, d.h. der Programmierer des PL muss kein Objekt erzeugen, sondern kann die Methoden
    // der Klasse direkt aufrufen, z.B. x = BOKunden.getKundenListe()
    // Dieses BO ist so konzipiert, dass der PL-Programmierer nie eine Klasse mit new instanzieren muss.
    public static class Main {

        // Hilfsmethode, die eine Verbindung zur DB erzeugt und retourniert.
        static internal SqlConnection GetConnection() {

                List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
                dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
                string conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DB\PM_DB.mdf;Integrated Security=True;Connect Timeout=5";

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }

        //Methode überprüft Userlogin und gibt ein Userobjekt zurpück wenn der Login erfolgreich war
        public static User checkLogin(string username, string pw) {
            string SQL = "select Username, Firstname, Lastname, Email from [User] where Username = @username and Password = @pw";            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("username", username));
            cmd.Parameters.Add(new SqlParameter("pw", pw));
            SqlDataReader reader = cmd.ExecuteReader();
            User u = new User();
            if (reader.HasRows){
                reader.Read();
                u.Username = reader.GetString(0);
                u.Firstname = reader.GetString(1);
                u.Lastname = reader.GetString(2);
                u.Email = reader.GetString(3);
                return u;
            }
            else return null;

        }

        //Methode registriert neuen User
        public static bool register(string fn, string ln, string un, string email, string pw){
            if (fn != "" && ln != "" && un != "" && email != "" && pw != "")
            {
                string SQL = "IF NOT EXISTS (SELECT Username FROM [User]  WHERE Username = @un) INSERT INTO [User] (Firstname, Lastname, Username, Email, Password) values ( @fn, @ln, @un, @email,@pw)";

                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("fn", fn));
                cmd.Parameters.Add(new SqlParameter("ln", ln));
                cmd.Parameters.Add(new SqlParameter("un", un));
                cmd.Parameters.Add(new SqlParameter("email", email));
                cmd.Parameters.Add(new SqlParameter("pw", pw));
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
            else return false;
        }

        public static Projects getUserProjects(string username)
        {
            return Project.LoadUserProjects(username);
        }

    }

}


