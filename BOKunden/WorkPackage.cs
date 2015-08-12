using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BO_PM
{
    /// <summary>
    ///  Objekte dieser Klasse repräsentieren eine WorckPackage von Projects
    /// </summary>
    public class WorkPackage
    {

//INTERNE VARIABLEN / FELDER

        private string mID = "";
        private string mProjectID; 
        private string mName;
        private string mDescription;
        private DateTime mCreatedDate;
        private DateTime mEndDate;

//PROPERTIES:
        public string ID { 
            get {return mID; }
            internal set { mID = value;}
        }
        public string ProjectID {
            get { return mProjectID; }
            internal set { mProjectID = value; }
        }
        public string Name {
            get { return mName; }
            set { mName = value; }
        }
        public string Description {
            get { return mDescription; }
            set { mDescription = value; }
        }
        public DateTime CreatedDate
        { //  kann man auch aus dem PL sehen - aber nicht ändern!
            get { return mCreatedDate; }
            set { mCreatedDate = value; }
        }
        public DateTime EndDate
        { //  kann man auch aus dem PL sehen - aber nicht ändern!
            get { return mEndDate; }
            set { mEndDate = value; }
        }

        internal WorkPackage() { } // internal constructor - verhindert erzeugung mit new aus dem PL
        
        public bool Save() {
            if (mID == "") {
                string SQL = "insert into WorkPackage (WorkpackageID, ProjectID, Description, Name, CreatedDate, EndDate) values (@id, @pid, @desc, @name, @cd, @ed)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id", Guid.NewGuid().ToString()));
                cmd.Parameters.Add(new SqlParameter("pid", ProjectID));
                cmd.Parameters.Add(new SqlParameter("name", Name));
                cmd.Parameters.Add(new SqlParameter("desc", Description));
                cmd.Parameters.Add(new SqlParameter("cd", CreatedDate));
                cmd.Parameters.Add(new SqlParameter("ed", EndDate));
                return (cmd.ExecuteNonQuery() > 0); 
            }else{
                //Insert WorkPackage in Project
                //bestehender Record -> UPDATE
                string SQL = "update Workpackage set ProjectID=@pid, Name=@name, Description=@desc, CreatedDate=@cd, EndDate=@ed where TaskID = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id", mID));
                cmd.Parameters.Add(new SqlParameter("pid", ProjectID));
                cmd.Parameters.Add(new SqlParameter("name", Name));
                cmd.Parameters.Add(new SqlParameter("desc", Description));
                cmd.Parameters.Add(new SqlParameter("cd", CreatedDate));
                cmd.Parameters.Add(new SqlParameter("ed", EndDate));
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
        }

        public bool Delete() {
            if (mID != "") {
                SqlCommand cmd = new SqlCommand("delete WorkPackage where WorkPackageID = @id", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("id", mID));
                if (cmd.ExecuteNonQuery() > 0) {
                    mID = "";
                    return true;
                }
                else return false;
            }
            else return true;
        }

    public Task addTask(string Name, DateTime CreatedDate, DateTime Enddate, string Description){
            if (mID == "") return null;
            else{
                Task t = new Task();
                t.WorkPackageID = mID;
                t.Name = Name;
                t.CreatedDate = CreatedDate;
                t.EndDate = Enddate;
                t.Description = Description;
                t.Save();                
                return t;
            }
        }


        public Tasks loadWorkPackageTasks()
        {
            if (mID != "")
            {
                SqlCommand cmd = new SqlCommand("select t.Name, t.Description, t.CreatedDate, t.EndDate, t.TaskID, t.WorkpackageID, t.Status from Task as t where WorkpackageID = @id", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("id", mID));
                SqlDataReader reader = cmd.ExecuteReader();
                Tasks ts = new Tasks();
                while (reader.Read())
                {
                    Task t = new Task();
                    t.Name = reader.GetString(0);
                    t.Description = reader.GetString(1);
                    t.ID = reader.GetString(4);
                    t.WorkPackageID = reader.GetString(5);
                    t.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    t.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    t.Status = reader.GetString(6);
                    ts.Add(t);
                }
                return ts;
            }
            else return null;
        }
    }
}