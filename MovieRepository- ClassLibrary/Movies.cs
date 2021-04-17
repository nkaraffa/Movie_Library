using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieRepository__ClassLibrary
{
    public class Movies         //DLL Backup in case of SQL link break or corruption
    {
        //Auto-Properties
        public decimal movieID { get; set; }
        public string title { get; set; }
        public int releaseDate { get; set; }
        public string director { get; set; }
        public string studio { get; set; }
        public string genre { get; set; }
        public bool checkStatus { get; set; }

        //Constructors
        public Movies()
        {

        }

        //Movie Generic List
        public List<Movies> movList;
        public void InitializationMovies()
        {
            movList = new List<Movies>();
            movList.Add(new Movies() { movieID = 1001, title = "Shrek", releaseDate = 05/18/2001, director = "Andrew Adamson", studio= "Dreamworks", genre = "Comedy", checkStatus=true });
            movList.Add(new Movies() { movieID = 1002, title = "Shrek 2", releaseDate = 05/19/2004, director = "Andrew Adamson", studio = "Dreamworks", genre = "Comedy", checkStatus = true });
            movList.Add(new Movies() { movieID = 1003, title = "Shrek the Third", releaseDate = 05/18/2007, director = "Chris Miller", studio = "Dreamworks", genre = "Comedy", checkStatus = true });
            movList.Add(new Movies() { movieID = 1004, title = "Shrek Forever After", releaseDate = 05/21/2010, director = "Mike Mitchell", studio = "Dreamworks", genre = "Comedy", checkStatus = true });
            movList.Add(new Movies() { movieID = 1005, title = "Dr. Strangelove or: ...", releaseDate = 01/29/1964, director = "Stanley Kubrick", studio = "Columbia Pictures", genre = "Comedy", checkStatus = true });
            movList.Add(new Movies() { movieID = 1006, title = "Pulp Fiction", releaseDate = 10/14/1994, director = "Quentin Tarantino", studio = "Miramax", genre = "Crime", checkStatus = true });
            movList.Add(new Movies() { movieID = 1007, title = "Goodfellas", releaseDate = 09/21/1990, director = "Martin Scorsese", studio = "Warner Bros.", genre = "Crime", checkStatus = true });
            movList.Add(new Movies() { movieID = 1008, title = "One Flew Over the Cuckoo's Nest", releaseDate = 11 / 19 / 1975, director = "Milos Forman", studio = "", genre = "Fanstasy Films", checkStatus = true });
            movList.Add(new Movies() { movieID = 1009, title = "Se7en", releaseDate = 09 / 22 / 1995, director = "David Fincher", studio = "Cecchi Gori Pictures", genre = "Crime", checkStatus = true });
            movList.Add(new Movies() { movieID = 1010, title = "Saving Private Ryan", releaseDate = 07 / 24 / 1998, director = "Steven Spielberg", studio = "Dreamworks", genre = "War", checkStatus = true });
            movList.Add(new Movies() { movieID = 1011, title = "Interstellar", releaseDate = 11 / 07 / 2014, director = "Christopher Nolan", studio = "Paramount Pictures", genre = "Sci-Fi", checkStatus = true });
            movList.Add(new Movies() { movieID = 1012, title = "Parasite", releaseDate = 11 / 08 / 2019, director = "Bong Joon Ho", studio = "Barunson E&A", genre = "Thriller", checkStatus = true });
            movList.Add(new Movies() { movieID = 1013, title = "The Usual Suspects", releaseDate = 08 / 16 / 1995, director = "Bryan Singer", studio = "PolyGram Filmed Entertainment", genre = "Crime", checkStatus = true });
            movList.Add(new Movies() { movieID = 1014, title = "Gladiator", releaseDate = 05 / 05 / 2000, director = "Ridley Scott", studio = "Dreamworks", genre = "Action", checkStatus = true });
            movList.Add(new Movies() { movieID = 1015, title = "The Intouchables", releaseDate = 11 / 02 / 2011, director = "Oliver Nakache", studio = "Quad Quad Productions", genre = "Drama", checkStatus = true });
            movList.Add(new Movies() { movieID = 1016, title = "The Prestige", releaseDate = 10 / 20 / 2006, director = "Christopher Nolan", studio = "Touchstone Pictures", genre = "Mystery", checkStatus = true });
            movList.Add(new Movies() { movieID = 1017, title = "Alien", releaseDate = 06 / 22 / 1979, director = "Ridley Scott", studio = "Brandywine Productions", genre = "Horror", checkStatus = true });
            movList.Add(new Movies() { movieID = 1018, title = "Joker", releaseDate = 10 / 04 / 2019, director = "Todd Phillips", studio = "Warner Bros.", genre = "Thriller", checkStatus = true });
            movList.Add(new Movies() { movieID = 1019, title = "Amadeus", releaseDate = 09 / 19 / 1984, director = "Milos Forman", studio = "AMLF", genre = "History", checkStatus = true });
            movList.Add(new Movies() { movieID = 1020, title = "Citizen Kane", releaseDate = 09 / 05 / 1941, director = "Orson Welles", studio = "RKO Radio Pictures", genre = "Drama", checkStatus = true });
            //movList.Add(new Movies() { movieID = 1021, title = "", releaseDate = 11 / 02 / 2011, director = "", studio = "", genre = "", checkStatus = true });
        }

        //Methods - Get, Add, Delete
        public List<Movies> GetMovies()
        {
            return movList;
        }
        public void AddMovies(Movies obj)
        {
            movList.Add(obj);
        }
        public void DeleteMovie (int movieID)
        {
            movList.RemoveAt(movieID);
        }
        public Movies IndexGet (int movieID)
        {
            return movList.ElementAt(movieID);
        }
    }
}
