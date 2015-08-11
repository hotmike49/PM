using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace BO_PM
{
    /// <summary>
    ///  Objekte dieser Klasse repräsentieren ein Project
    /// </summary>
    public class Project
    {

//INTERNE VARIABLEN / FELDER

        private string mID = "";
        private string mOwnerName; 
        private string mName;
        private string mDescription;
        private DateTime mCreatedDate;
        private DateTime mEndDate;

//PROPERTIES:
        public string ID { 
            get {return mID; }
            internal set { mID = value;}
        }
        public string OwnerName { 
            get {return mOwnerName; }
            internal set { mOwnerName = value;}
        }
        public string Name {
            get { return mName; }
            set { mName = value; }
        }
        public string Description {
            get { return mDescription; }
            set { mDescription = value; }
        }
        public DateTime CreatedDate{ //  kann man auch aus dem PL sehen - aber nicht ändern!
            get { return mCreatedDate; }
            internal set { mCreatedDate = value; }
        }
        public DateTime EndDate { //  kann man auch aus dem PL sehen - aber nicht ändern!
            get { return mEndDate; }
            internal set { mEndDate = value; }
        }
        internal Project() { } // internal constructor - verhindert erzeugung mit new aus dem PL
        
        public bool Save() {
            if (mID == "") {
                string SQL = "insert into Project (ProjectID, Ownername, Name, Description, CreatedDate, EndDate) values (@id, @on, @name, @desc, @cd, @ed)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                mID = Guid.NewGuid().ToString();
                cmd.Parameters.Add(new SqlParameter("id", mID));
                cmd.Parameters.Add(new SqlParameter("on", OwnerName));
                cmd.Parameters.Add(new SqlParameter("name", Name));
                cmd.Parameters.Add(new SqlParameter("desc", Description));
                cmd.Parameters.Add(new SqlParameter("cd", CreatedDate));
                cmd.Parameters.Add(new SqlParameter("ed", EndDate));
                return (cmd.ExecuteNonQuery() > 0);
            }else{      
                //bestehender Record -> UPDATE
                string SQL = "update Project set ProjectID=@id, Ownername=@on, Name=@name, Description=@desc, CreatedDate=@cd, EndDate=@ed where ProjectID = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id", mID));
                cmd.Parameters.Add(new SqlParameter("on", OwnerName));
                cmd.Parameters.Add(new SqlParameter("name", Name));
                cmd.Parameters.Add(new SqlParameter("desc", Description));
                cmd.Parameters.Add(new SqlParameter("cd", CreatedDate));
                cmd.Parameters.Add(new SqlParameter("ed", EndDate));
                return (cmd.ExecuteNonQuery() > 0); 
            }
        }

        public bool Delete() {
            if (mID != "") {
                SqlCommand cmd = new SqlCommand("delete Project where ProjectID = @id", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("id", mID));
                if (cmd.ExecuteNonQuery() > 0) {
                    mID = "";
                    return true;
                }
                else return false;
            }
            else return true;
        }

        public bool addWorkPackage(string Name, DateTime Enddate) {
            if (mID == "") return false;
            else{
                WorkPackage w = new WorkPackage();
                w.ID = Guid.NewGuid().ToString();
                w.ProjectID = mID;
                w.Name = Name;
                w.EndDate = Enddate;
                w.CreatedDate = DateTime.Today;
                w.Save();
                return true;
            }
        }


        public bool addProjectUser(string username){            
             if(username!=""){
                //string SQL = "insert into UserProject (ProjectID, Username) values (@id, @uid)";
                string SQL = "IF NOT EXISTS (SELECT Username, ProjectID FROM UserProject  WHERE Username = @un AND ProjectID = @pid) insert into UserProject (ProjectID, Username) values (@pid, @un)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("pid", mID));
                cmd.Parameters.Add(new SqlParameter("un", username));
                return (cmd.ExecuteNonQuery() > 0);
            }else return true; 
       }

        public bool deleteProjectUser(string username){            
             if(username!=""){                
                SqlCommand cmd = new SqlCommand("delete UserProject where ProjectID = @id and Username = @un", Main.GetConnection());
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id", mID));
                cmd.Parameters.Add(new SqlParameter("un", username));
                return (cmd.ExecuteNonQuery() > 0);
            }else return true; 
       }
       

       
        internal static Project load(string ID)
        {
            if (ID != ""){
                SqlCommand cmd = new SqlCommand("select p.ProjectID, p.OwnerName, p.Name, p.Description, p.CreatedDate, p.EndDate from Project where ID = @id", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("id", ID));
                SqlDataReader reader = cmd.ExecuteReader();
                Project p = new Project();
                p.ID = reader.GetString(0);
                p.OwnerName = reader.GetString(1);
                p.Name = reader.GetString(2);
                p.Description = reader.GetString(3);
                p.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                p.EndDate = Convert.ToDateTime(reader["EndDate"]);
                return p;
            }
            else return null;            
        }

        internal static Projects LoadUserProjects(string username)
        {
            if (username != "")
            {
                SqlCommand cmd = new SqlCommand("select p.ProjectID, p.OwnerName, p.Name, p.Description, p.CreatedDate, p.EndDate from UserProject as up inner join Project as p on p.ProjectID = up.ProjectID where up.Username = @un", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("un", username));
                SqlDataReader reader = cmd.ExecuteReader();
                Projects userProjects = new Projects();
                while (reader.Read())
                {
                    Project p = new Project();
                    p.ID = reader.GetString(0);
                    p.OwnerName = reader.GetString(1);
                    p.Name = reader.GetString(2);
                    p.Description = reader.GetString(3);
                    p.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    p.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    userProjects.Add(p);
                }
                return userProjects;
            }
            else return null;            
        }
    }
}