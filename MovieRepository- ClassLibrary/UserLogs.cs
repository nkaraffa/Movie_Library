using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRepository__ClassLibrary
{
    class UserLogs         //DLL Backup in case of SQL link break or corruption
    {
        //Auto-Properties
        public decimal userLogID { get; set; }
        public string userName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        //Constructors
        public UserLogs()
        {

        }

        //Movie Generic List
        public List<UserLogs> userList;
        public void InitializationUsers()
        {
            userList = new List<UserLogs>();
            userList.Add(new UserLogs() { userLogID = 2001, userName = "movGuy", FirstName = "Jeff", LastName = "Bezos", password = "password", role = "User" });
            userList.Add(new UserLogs() { userLogID = 2002, userName = "movGuy2", FirstName = "John", LastName = "Doe", password = "password", role = "User" });
            userList.Add(new UserLogs() { userLogID = 2003, userName = "movGirl", FirstName = "Jane", LastName = "Doe", password = "password", role = "User" });
            userList.Add(new UserLogs() { userLogID = 2004, userName = "admin", FirstName = "Good", LastName = "News", password = "password99", role = "Admin" });
        }

        //Methods - Get, Add, Delete
        public List<UserLogs> GetUserLog()
        {
            return userList;
        }
        public void AddUserLog(UserLogs obj)
        {
            userList.Add(obj);
        }
        public void DeleteUsers(int userLogID)
        {
            userList.RemoveAt(userLogID);
        }
        public UserLogs IndexGetUserLog(int userLogID)
        {
            return userList.ElementAt(userLogID);
        }
    
    }
}
