using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //Allows the MovieLog data to be accessed from everywhere in the namespace
    class Global
    {
        public static Movie_LogEntities entities;  //Link to the database

        public static decimal userID;
        public static string userName;
    }

}
