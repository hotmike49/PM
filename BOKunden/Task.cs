using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BO_PM
{
    /// <summary>
    ///  Objekte dieser Klasse repräsentieren einen Kommentar zu einem bestimmten Kunden
    /// </summary>
    public class Task
    {

//INTERNE VARIABLEN / FELDER

        private string mID = "";
        private string mWorkPackageID; 
        private string mName;
        private string mDescription;
        private DateTime mCreatedDate;
        private DateTime mEndDate;
        private string mStatus = "0";

//PROPERTIES:
        public string ID { 
            get {return mID; }
            internal set { mID = value;}
        }
        public string WorkPackageID {
            get { return mWorkPackageID; }
            internal set { mWorkPackageID = value; }
        }
        public string Name {
            get { return mName; }
            set { mName = value; }
        }
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        public DateTime CreatedDate
        { //  kann man auch aus dem PL sehen - aber nicht ändern!
            get { return mCreatedDate; }
            set { mCreatedDate = value; }
        }
        public DateTime EndDate { 
            get { return mEndDate; }
            set { mEndDate = value; }
        }

        public string Status{
            get
            {
                if (mStatus == "0")
                    return "In Progress";
                else
                    return "Done";
            }
            set
            {
                mStatus = value;
            }
        }

        public Users TaskUsers{
            get
            {
                return User.LoadTaskUsers(this);
            }
        }
        internal Task() { } // internal constructor - verhindert erzeugung mit new aus dem PL
 
        //METHODS
        public bool Save() {
            if (mID == ""){
                string SQL = "insert into Task (TaskID, WorkPackageID, Name, Description, CreatedDate, EndDate, Status) values (@id, @wid, @name, @desc, @cd, @ed, @status)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();   
                mID = Guid.NewGuid().ToString();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id",  mID));
                cmd.Parameters.Add(new SqlParameter("wid", WorkPackageID));
                cmd.Parameters.Add(new SqlParameter("name", Name));
                cmd.Parameters.Add(new SqlParameter("desc", Description));
                cmd.Parameters.Add(new SqlParameter("cd", CreatedDate));
                cmd.Parameters.Add(new SqlParameter("ed", EndDate));
                cmd.Parameters.Add(new SqlParameter("status", mStatus));
                return (cmd.ExecuteNonQuery() > 0); 
            }else{
                //bestehender Record -> UPDATE
                string SQL = "update Task set WorkPackageID=@wid, Name=@name, Description=@desc, CreatedDate=@cd, EndDate=@ed, Status=@status where TaskID = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id", mID));
                cmd.Parameters.Add(new SqlParameter("wid", WorkPackageID));
                cmd.Parameters.Add(new SqlParameter("name", Name));
                cmd.Parameters.Add(new SqlParameter("cd", CreatedDate));
                cmd.Parameters.Add(new SqlParameter("desc", Description));
                cmd.Parameters.Add(new SqlParameter("status", mStatus));
                cmd.Parameters.Add(new SqlParameter("ed", EndDate));
                return (cmd.ExecuteNonQuery() > 0); //hat der INSERT geklappt, sollte genau ein Record verändert worden sein
            }
        }

        public bool Delete() {
            if (mID != "") {
                SqlCommand cmd = new SqlCommand("delete Task where TaskID = @id", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("id", mID));
                if (cmd.ExecuteNonQuery() > 0) {
                    mID = "";
                    return true;
                }
                else return false; //Löschen aus DB klappt nicht, vielleicht hat jemand anderer schon den Kommentar gelöscht?
            }
            else return true;
        }

        public bool addTaskUser(string username){
            if (username != ""){
                string SQL = "IF NOT EXISTS (SELECT Username, TaskID FROM UserTask  WHERE Username = @username AND TaskID = @tid) insert into UserTask (TaskID, Username) values (@tid, @username)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Main.GetConnection();
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("tid", mID));
                cmd.Parameters.Add(new SqlParameter("username", username));
                return cmd.ExecuteNonQuery() > 0;
            } else return false;
        }

        public bool deleteTaskUser(string username)
        {
            if (username != "")
            {
                SqlCommand cmd = new SqlCommand("delete UserTask where TaskID = @id and Username = @un", Main.GetConnection());
                //Die Parameter in SQL-String mit Werten versehen...
                cmd.Parameters.Add(new SqlParameter("id", mID));
                cmd.Parameters.Add(new SqlParameter("un", username));
                return (cmd.ExecuteNonQuery() > 0);
            }
            else return true;
        }

        internal static Task load(string ID){
            if (ID != ""){
                SqlCommand cmd = new SqlCommand("select TaskID, WorkPackageID, Name, CreatedDate, EndDate from Task where ID = @id", Main.GetConnection());
                cmd.Parameters.Add(new SqlParameter("id", ID));
                SqlDataReader reader = cmd.ExecuteReader();
                
                Task t = new Task();
                t.ID = reader.GetString(0);
                t.WorkPackageID = reader.GetString(1);
                t.Name = reader.GetString(2);
                t.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                t.EndDate = Convert.ToDateTime(reader["EndDate"]);
                return t;
            }
            else return null;            
        }

        
       // Laden aller Tasks die einem User zugeordnet sind
        internal static Tasks LoadUserTasks(User u)        {
            SqlCommand cmd = new SqlCommand("select t.TaskID, t.WorkPackageID, t.Name, t.CreatedDate, t.EndDate, t.Description  from UserTask as ut inner join Task as t on ut.TaskID = t.TaskID where Username = @username and t.status = '0'", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("username", u.Username));
            SqlDataReader reader = cmd.ExecuteReader();
            Tasks userTasks = new Tasks();
            while (reader.Read()) {
                Task t = new Task();
                t.ID = reader.GetString(0);
                t.WorkPackageID = reader.GetString(1);
                t.Name = reader.GetString(2);
                t.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                t.EndDate = Convert.ToDateTime(reader["EndDate"]);
                t.Description = reader.GetString(5);
                
                userTasks.Add(t);
            }
            return userTasks;
        }

        // Laden aller User die einem Task zugeordnet sind
        public Users loadTaskUsers(){
            SqlCommand cmd = new SqlCommand("select u.Username, u.Firstname, u.Lastname, u.Email from UserTask as ut inner join [User] as u on ut.Username = u.Username where TaskID = @tid", Main.GetConnection());
            cmd.Parameters.Add(new SqlParameter("tid", mID));
            SqlDataReader reader = cmd.ExecuteReader();
            Users taskUsers = new Users();
            while (reader.Read())
            {
                User u = new User();
                u.Username = reader.GetString(0);
                u.Firstname = reader.GetString(1);
                u.Lastname = reader.GetString(2);
                u.Email = reader.GetString(3);                
                taskUsers.Add(u);
            }
            return taskUsers;
        }

    }
}
