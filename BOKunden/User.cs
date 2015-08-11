using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace BO_PM
{
    public class User {

// FELDER bzw. VARIABLEN *********************************************************************************************

        private string mFirstname;
        private string mLastname;
        private string mEmail;
        private string mUsername ="";        

// PROPERTIES *********************************************************************************************
        // die ID wird ansich nie (von aussen) geschrieben, da sie ja als GUID beim Speichern erzeugt wird. 
        
        public string Username { //readonly für den PL
            get { return mUsername; } //auslesen darf man sie aber natürlich schon
            internal set { mUsername = value; }//aus dem eigenen Projekt (BOKunden) heraus darf ich das Feld aber schreiben!
        }

        public string Firstname {
            get { return mFirstname; }
            set { mFirstname = value; }
        }

        public string Lastname {
            get { return mLastname; }
            set { mLastname = value; }
        }

        public string Email {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public Projects MyProjects {
            get{
                return Project.LoadUserProjects(mUsername);
            }
        }

        public Tasks MyTasks {
            get {
                return Task.LoadUserTasks(this);
            }
        }


// METHODEN *********************************************************************************************

        // Dieser Konstruktor macht gar nichts, aber, da er internal ist, kann er nur von innerhalb des BO
        // aufgerufen werden - also nicht vom PL aus - so verhindere ich, dass ein PL-Programmierer die
        // Klasse Kunde mit new instanzieren kann. (er soll dafür die Methoden in der statischen Klasse Main verwenden)
        internal User() { 
        }

        //Methode erkennt an der mUsername, ob dieses Objekt schon in der DB existiert oder nicht (dann ist die ID leer)
        //Ob in der DB INSERT oder UPDATE verwendet wird, entscheidet die Methode selbst!
        public bool Save() {
            if (mUsername != "")
            {
                //user wird über Main.register hinzugefügt
                //bestehender Record -> UPDATE
                string SQL = "update User set Firstname=@fn, Lastname=@ln, Email=@email where username = @username";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //GUID für ID erzeugen und als String zurückgeben (weil mUsername=="")!
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("username", mUsername));
                cmd.Parameters.Add(new SqlParameter("fn", Firstname));
                cmd.Parameters.Add(new SqlParameter("ln", Lastname));
                cmd.Parameters.Add(new SqlParameter("email", Email));
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
            else return false;
        }

        public Project addProject(string Name, DateTime Startdate, DateTime Enddate, string Desc){
            if (mUsername == "") return null;
            else{ 
                Project p = new Project();
                p.OwnerName = mUsername;
                p.Name = Name;
                p.Description = Desc;
                p.EndDate = Enddate;
                p.CreatedDate = Startdate;                
                if(p.Save()) return p;
                else return null;
            }
        }

        public bool changePassword(string pw){
              if (mUsername != ""){
                string SQL = "update User set Password=@pw where username = @username";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                cmd.Parameters.Add(new SqlParameter("username", mUsername));
                cmd.Parameters.Add(new SqlParameter("pw", pw));
                return (cmd.ExecuteNonQuery() > 0); 
            }
            else return false;
        }

/************************************************************************************************************
STATISCHE METHODEN
internal bedeutet, dass sie nur von Klassen aus BOKunden (aus dem eigenem Namespace) aufgerufen werden können 
- also nicht direkt aus dem PL

Die Methoden sind im BOKunde-Objekt, damit der BO-Programmierer alle SQL-Statements, die Kunden betreffen, an einer Stelle hat
Der PL-Programmierer sieht diese Implementation aber nicht. Er sieht die Methoden, von wo aus er diese Objekte "bekommt"
(also entsprechend der Navigability). Man hätte diese Methoden technisch aber problemlos auch in die cMain geben können!
*/

        // Laden aller Tasks die einem User zugeordnet sind
        internal static Users LoadTaskUsers(Task t)
        {
            if (t.ID != "")
            {
                SqlCommand cmd = new SqlCommand("select u.Firstname, u.Lastname, u.Username, u.Email from UserTask as ut inner join User as t on ut.Username = u.Username where TaskID = @tid", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("tid", t.ID));
                SqlDataReader reader = cmd.ExecuteReader();
                Users taskUsers = new Users();
                while (reader.Read())
                {
                    User u = new User();
                    u.Firstname = reader.GetString(0);
                    u.Lastname = reader.GetString(1);
                    u.Username = reader.GetString(2);
                    u.Email = reader.GetString(3);
                    taskUsers.Add(u);
                }
                return taskUsers;
            }
            else return null;
        }

        internal static Users LoadProjectUsers(Project p)
        {
            if (p.ID != "")
            {
                SqlCommand cmd = new SqlCommand("select u.Firstname, u.Lastname, u.Username, u.Email from UserProject as up inner join [User] as u on up.Username = u.Username where ProjectID = @pid", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("pid", p.ID));
                SqlDataReader reader = cmd.ExecuteReader();
                Users projectUsers = new Users();
                while (reader.Read())
                {
                    User u = new User();
                    u.Firstname = reader.GetString(0);
                    u.Lastname = reader.GetString(1);
                    u.Username = reader.GetString(2);
                    u.Email = reader.GetString(3);
                    projectUsers.Add(u);
                }
                return projectUsers;
            }
            else return null;
        }

        internal static Users LoadAllUsers()
        {
            SqlCommand cmd = new SqlCommand("select Firstname, Lastname, Username, Email from [User]", Main.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Users allUsers = new Users();
            while (reader.Read())
            {
                User u = new User();
                u.Firstname = reader.GetString(0);
                u.Lastname = reader.GetString(1);
                u.Username = reader.GetString(2);
                u.Email = reader.GetString(3);
                allUsers.Add(u);
            }
            return allUsers;
        
        }
    } // Ende Klasse
} // Ende Namespace
