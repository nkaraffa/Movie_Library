# Movie_Library
Project that creates a movie library and checkout interface.

_________________________

Problem Statement:  

  Create an interactive movie library with a User and Admin view. 
  

Database use : SQL 
  

Brief Description: 

  The interactive library will be able to get, update, add, delete, and query movies by genre. The user will only be able to get, query, and log movies from the User view.  The   Admin view will allow the user to get, update, add, delete, and query movies by genre.
  

Workflow (Movie Management System): 

  Log-on Menu
  
    a. Displays current movies in store on main screen
    b. Log-in menu and credentials check
    c. Sends user to either the User or Admin portal

  User Menu - Default view of the library will be the user screen

    1. Movie Query
      a. Get a list of the available movies
      b. Query movies by genre, title, or ID #
      
    2. Check Out Log Query
      a. Get a list of currently checked out movies by User ID (unique to each user profile)
      
    3. Check Out Movies & Save to SQL
      a. Selected movies logs will be printed to the screen for user (receipt)
      b. User selection (shopping cart) is saved to SQL database once checked out
      c. Check Out Log is updated for user
    
  Admin Menu - CRUD features are avaiable

    1. Movie Query
      a. Get a list of the available movies
      b. Query movies by genre
      
    2. Modify Movie Table (CRUD)
      a. Update movie data entries
      b. Add new movie data entries
      c. Delete movie data entries
      
    3. Modify User Table (CRUD)
      a. Get a list of the current Users
      b. Update Users data entries
      c. Add new Users data entries
      d. Delete Users data entries
      
    4. Checked Out Movies Query
      a. Get a list of the available movies
