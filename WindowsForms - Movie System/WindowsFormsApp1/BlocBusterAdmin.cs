using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MovieRepository__ClassLibrary;  //Referencing the seperate file "MovieRepository"

namespace WindowsFormsApp1
{ 
    public partial class Bloc_Buster_Form : Form
    {
        //Movies mov;       //Library Instantiation - Global Variable (DLL)

        public Bloc_Buster_Form()
        {
            InitializeComponent();
        }
        private void Bloc_Buster_Form_Load(object sender, EventArgs e)
        {
            Global.entities = new Movie_LogEntities();
            dataGrdAdmin.DataSource = Global.entities.Movies.ToList();  //Links the dataGrid to the Movies data Table
            dataGrdAdmin.ReadOnly = true;

            txtBxCurrentUser.AppendText("Welcome " + Global.userName);
            txtBxCurrentUser.ReadOnly = true;
            ComboBxAdd();
            DateTimeDefault();                //Blanks out the date-picker until the User selects a date

            grpBoxAdd.Visible = false;
            grpBxUpdate.Visible = false;
            grpBxUserAdd.Visible = false;
            grpBxUserUpdate.Visible = false;
            menuStrip1.Visible = true;
        }


        //Global Variables
        #region Global Variables

        bool dataShowingMovies = true;      //Checks if data displayed is Movies or User info
        bool datashowingCheckOut = false;   //Checks if data displayed is Checkout info

        decimal movieIDValue;       //Add Movie variable:  auto sets the ID value to NEW value
        decimal userIDValue;        //Add User variable:  auto sets the ID value to NEW value

        decimal selectedMovID;      //Update Movie variable:    auto sets the ID value to User selection
        decimal selectedUserID;     //Allows User info to be deleted

        #endregion

        //Methods - [ComboBx Entries (Genre / Role), RefreshData, DateTimeDefault, MovieIDSet, UserIDSet, ClearEntry]
        #region Methods

        //ComboBx Entries - (Genre / Role)
        public void ComboBxAdd()
        {
            //Movie Genre values
            var genreVal = (from Movie_Log in Global.entities.Movies
                            select Movie_Log);

            foreach (Movy genre in genreVal)               //Adds combobox entries for all Movie items
            {
                if (!cbAddMov.Items.Contains(genre.Genre))
                {
                    cbSearchMov.Items.Add(genre.Genre);
                    cbAddMov.Items.Add(genre.Genre);                    
                    cbUpdateMov.Items.Add(genre.Genre);
                }
            }

            //User Role values
            var roleVal = (from Movie_Log in Global.entities.Users
                           select Movie_Log);

            foreach (User role in roleVal)               //Adds combobox entries for all User items
            {
                if (!cbUserRole.Items.Contains(role.Role))
                {
                    cbUserRole.Items.Add(role.Role);
                }
            }
        }

        //Refresh Data
        public void RefreshData()
        {
            if (dataShowingMovies == true)
            {
                dataGrdAdmin.SelectionChanged -= dataGrdAdmin_SelectionChanged;     //Unassign the event to prevent datasource error
                dataGrdAdmin.DataSource = null;
                dataGrdAdmin.DataSource = Global.entities.Movies.ToList();
                dataGrdAdmin.SelectionChanged += dataGrdAdmin_SelectionChanged;     //Reassign the event to continue use

                grpBoxSearch.Visible = true;  //Display Search menu
                grpBxUserAdd.Visible = false; //Hide Add User menu
                grpBxUserUpdate.Visible = false; //Hide Update User menu
            }
            else if (dataShowingMovies == false)
            {
                dataGrdAdmin.SelectionChanged -= dataGrdAdmin_SelectionChanged;     //Unassign the event to prevent datasource error
                dataGrdAdmin.DataSource = null;
                dataGrdAdmin.DataSource = Global.entities.Users.ToList();
                dataGrdAdmin.SelectionChanged += dataGrdAdmin_SelectionChanged;     //Reassign the event to continue use
            }
        }

        //DateTimeDefault - Blanks out the date-picker
        public void DateTimeDefault()
        {
            dtTimePkSearch.CustomFormat = " ";
            dtTimePkSearch.Format = DateTimePickerFormat.Custom;

            dtTimePkAdd.CustomFormat = " ";
            dtTimePkAdd.Format = DateTimePickerFormat.Custom;

            //dtTimePkUpdate.CustomFormat = " ";
            //dtTimePkUpdate.Format = DateTimePickerFormat.Custom;          
        }

        //MovieIDSet - Automatically sets the MovieID value to prevent DB error
        public void MovieIDSet()
        {
            movieIDValue = 0;            //Resets the ID before every ID check

            var movID = (from Movie_Log in Global.entities.Movies
                            select Movie_Log);

            foreach (Movy id in movID)               //Adds combobox entries for all User items
            {
                if (movieIDValue <= id.Movie_ID)
                {
                    movieIDValue = id.Movie_ID;
                    movieIDValue++;
                }
            }

            txtIDAdd.Text = Convert.ToString(movieIDValue);
        }

        //UserIDSet - Automatically sets the UserID value to prevent DB error
        public void UserIDSet()
        {
            userIDValue = 0;            //Resets the ID before every ID check

            var userID = (from Movie_Log in Global.entities.Users
                         select Movie_Log);

            foreach (User id in userID)               //Adds combobox entries for all User items
            {
                if (userIDValue <= id.User_ID)
                {
                    userIDValue = id.User_ID;
                    userIDValue++;
                }
            }

            txtUserID.Text = Convert.ToString(userIDValue);
        }

        //ClearEntry - clears entry boxes to prevent duplication and 'clean' GUI
        public void ClearEntry(int i)
        {
            if (i == 1)                 //Clear search bars
            {
                txtBxMovID.Clear();
                txtBxTitle.Clear();
                dtTimePkSearch.ResetText();
                txtBxDir.Clear();
                txtBxStudio.Clear();
                cbSearchMov.ResetText();
            }
            else if (i == 2)            //Clears add bars
            {
                txtTitleAdd.Clear();
                dtTimePkAdd.ResetText();
                txtDirAdd.Clear();
                txtStudAdd.Clear();
                cbAddMov.ResetText();
            }
            else if (i == 3)            //Clears add User bars
            {
                txtUserName.Clear();
                txtUserFName.Clear();
                txtUserLName.Clear();
                txtUserPass.Clear();
                cbUserRole.ResetText();
            }
            
        }
        #endregion


        //Menu Options - File (Exit / Log Off), Add Movies, Update Movies, Add User, Checked Out Log
        #region Menu Options

        //Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Log Off - returns user to log-on screen
        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LogonPage formLogOn = new LogonPage();
            formLogOn.Show();
        }

        //Add Movies - displays or hides add movie option
        private void addMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataShowingMovies = true;       //Changes refresh option to Movies
            datashowingCheckOut = false;    //Changes checkout data option

            if (grpBoxAdd.Visible == false)
            {
                grpBoxAdd.Visible = true;
                btnRefresh.Visible = true;
                btnDelete.Visible = true;
                RefreshData();

                MovieIDSet();                        //Automatically sets ID value and locks the field
                txtIDAdd.Enabled = false;                
            }
            else
            {
                grpBoxAdd.Visible = false;
            }
        }

        //Update Movies - displays or hides add movie option
        private void updateMoviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataShowingMovies = true;       //Changes refresh option to Movies
            datashowingCheckOut = false;    //Changes checkout data option

            if (grpBxUpdate.Visible == false)
            {
                grpBxUpdate.Visible = true;
                btnRefresh.Visible = true;
                btnDelete.Visible = true;
                RefreshData();

                txtIDUpdate.Text = Convert.ToString(selectedMovID);          //Automatically sets ID value and locks the field
                txtIDUpdate.Enabled = false;
            }
            else
            {
                grpBxUpdate.Visible = false;
            }
        }

        //Add User - displays or hides add User option && displays User data
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataShowingMovies = false;      //Changes refresh option to Users
            datashowingCheckOut = false;    //Changes checkout data option

            if (grpBxUserAdd.Visible == false)
            {
                grpBxUserAdd.Visible = true;
                grpBxUserUpdate.Visible = true;

                dataGrdAdmin.SelectionChanged -= dataGrdAdmin_SelectionChanged;     //Unassign the event to prevent datasource error
                Global.entities = new Movie_LogEntities();
                dataGrdAdmin.DataSource = Global.entities.Users.ToList();           //Links the dataGrid to the Movies data Table               
                dataGrdAdmin.SelectionChanged += dataGrdAdmin_SelectionChanged;     //Reassign the event to continue use

                grpBoxAdd.Visible = false;
                grpBxUpdate.Visible = false;
                grpBoxSearch.Visible = false;
                btnRefresh.Visible = true;
                btnDelete.Visible = true;

                UserIDSet();                        //Automatically sets ID value and locks the field
                txtUserID.Enabled = false;
                txtUserUpdID.Enabled = false;
            }
            else
            {
                dataShowingMovies = true;   //Changes refresh option to Movies
                grpBxUserAdd.Visible = false;
                grpBxUserUpdate.Visible = false;
                RefreshData();                
            }
        }

        //CheckedOut Log - 
        private void outLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGrdAdmin.SelectionChanged -= dataGrdAdmin_SelectionChanged;     //Unassign the event to prevent datasource error
            if (datashowingCheckOut == false)
            {
                datashowingCheckOut = true;
                dataGrdAdmin.SelectionChanged -= dataGrdAdmin_SelectionChanged;     //Unassign the event to prevent datasource error

                Global.entities = new Movie_LogEntities();
                dataGrdAdmin.DataSource = Global.entities.CheckOuts.ToList();           //Links the dataGrid to the Movies data Table     

                this.dataGrdAdmin.Columns["Movy"].Visible = false;                      //Hide foreign key columns
                this.dataGrdAdmin.Columns["User"].Visible = false;                      //Hide foreign key columns
                btnRefresh.Visible = false;
                btnDelete.Visible = false;
                grpBoxSearch.Visible = false;
                grpBoxAdd.Visible = false;
                grpBxUpdate.Visible = false;
                grpBxUserUpdate.Visible = false;
                grpBxUserAdd.Visible = false;
            }
            else if (datashowingCheckOut == true)
            {
                datashowingCheckOut = false;
                dataGrdAdmin.SelectionChanged += dataGrdAdmin_SelectionChanged;     //Reassign the event to continue use

                RefreshData();
                btnRefresh.Visible = true;
                btnDelete.Visible = true;
                grpBoxSearch.Visible = true;
            }
        }

        #endregion


        //Event Handlers - Movies (Refresh, Search, Add), Users (Add), Delete, Selection Ques (DataGrid / DatePickers)
        #region Event Handlers

        //Refresh Data
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        //Search Data - (ID, Title, ReleaseDate, Director, Studio, Genre)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSearchMov.Text != "" && txtBxTitle.Text == "" && txtBxMovID.Text == "" && dtTimePkSearch.Value.Date == DateTime.Now.Date && txtBxDir.Text == "" && txtBxStudio.Text == "")    //ComboBx Only
                {
                    var data = (from Movie_Log in Global.entities.Movies
                                where cbSearchMov.Text == Movie_Log.Genre
                                select Movie_Log);
                    dataGrdAdmin.DataSource = data.ToList();
                }
                else if (cbSearchMov.Text == "" && txtBxTitle.Text == "" && txtBxMovID.Text != "" && dtTimePkSearch.Value.Date == DateTime.Now.Date && txtBxDir.Text == "" && txtBxStudio.Text == "")     //Movie ID Only
                {
                    var data = (from Movie_Log in Global.entities.Movies
                                where txtBxMovID.Text == Movie_Log.Movie_ID.ToString()
                                select Movie_Log);
                    dataGrdAdmin.DataSource = data.ToList();
                }
                else if (cbSearchMov.Text == "" && txtBxTitle.Text != "" && txtBxMovID.Text == "" && dtTimePkSearch.Value.Date == DateTime.Now.Date && txtBxDir.Text == "" && txtBxStudio.Text == "")     //Title Only
                {
                    var data = (from Movie_Log in Global.entities.Movies
                                where txtBxTitle.Text == Movie_Log.Title
                                select Movie_Log);
                    dataGrdAdmin.DataSource = data.ToList();
                }                
                else if (cbSearchMov.Text == "" && txtBxTitle.Text == "" && txtBxMovID.Text == "" && dtTimePkSearch.Value.Date == DateTime.Now.Date && txtBxDir.Text == "" && txtBxStudio.Text == "")     //ReleaseDate Only
                {
                    var data = (from Movie_Log in Global.entities.Movies
                                where dtTimePkSearch.Value.Date == Movie_Log.Release_Date
                                select Movie_Log);
                    dataGrdAdmin.DataSource = data.ToList();
                }
                else if (cbSearchMov.Text == "" && txtBxTitle.Text == "" && txtBxMovID.Text == "" && dtTimePkSearch.Value.Date == DateTime.Now.Date && txtBxDir.Text != "" && txtBxStudio.Text == "")     //Director Only
                {
                    var data = (from Movie_Log in Global.entities.Movies
                                where txtBxDir.Text == Movie_Log.Director
                                select Movie_Log);
                    dataGrdAdmin.DataSource = data.ToList();
                }
                else if (cbSearchMov.Text == "" && txtBxTitle.Text == "" && txtBxMovID.Text == "" && dtTimePkSearch.Value.Date == DateTime.Now.Date && txtBxDir.Text == "" && txtBxStudio.Text == "")     //Studio Only
                {
                    var data = (from Movie_Log in Global.entities.Movies
                                where txtBxStudio.Text == Movie_Log.Studio
                                select Movie_Log);
                    dataGrdAdmin.DataSource = data.ToList();
                }
                else if (cbSearchMov.Text != "" && txtBxTitle.Text != "" && txtBxMovID.Text != "" && dtTimePkSearch.Value.Date == DateTime.Now.Date && txtBxDir.Text != "" && txtBxStudio.Text != "")     //All Fields
                {
                    var data = (from Movie_Log in Global.entities.Movies
                                where cbSearchMov.Text == Movie_Log.Genre && txtBxTitle.Text == Movie_Log.Title && txtBxMovID.Text == Movie_Log.Movie_ID.ToString() &&
                                      dtTimePkSearch.Value.Date == Movie_Log.Release_Date && txtBxDir.Text == Movie_Log.Director && txtBxStudio.Text == Movie_Log.Studio
                                select Movie_Log);
                    dataGrdAdmin.DataSource = data.ToList();
                }
                else if ((cbSearchMov.Text != "" && txtBxTitle.Text != "") || (cbSearchMov.Text != "" && txtBxMovID.Text != "") || (txtBxTitle.Text != "" && txtBxMovID.Text != ""))
                {
                    MessageBox.Show("Please input all boxes.");
                }
                else
                {
                    MessageBox.Show("Please only search by one value OR input all boxes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }

            ClearEntry(1);
        }

        //Add Movie
        private void btnAdd_Click(object sender, EventArgs e)
        {            
            try
            {
                MovieIDSet();   //Last validation of ID value;

                if (cbAddMov.Text != "" && txtTitleAdd.Text != "" && txtIDAdd.Text != "" && dtTimePkAdd.Value.Date != DateTime.Now.Date && txtDirAdd.Text != "" && txtStudAdd.Text != "")
                {
                    Movy newMov = new Movy();

                    newMov.Movie_ID = movieIDValue;       //Automatically set to prevent DB error
                    newMov.Title = txtTitleAdd.Text;
                    newMov.Release_Date = dtTimePkAdd.Value.Date;
                    newMov.Director = txtDirAdd.Text;
                    newMov.Studio = txtStudAdd.Text;
                    newMov.Genre = cbAddMov.Text;

                    Global.entities.Movies.Add(newMov);
                    Global.entities.SaveChanges();

                    RefreshData();
                    MovieIDSet();   //Reset of preset ID value;
                }
                else
                {
                    MessageBox.Show("Please input all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }

            ClearEntry(2);
        }

        //Update Movie
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbUpdateMov.Text != "" && txtTitleUpdate.Text != "" && txtIDUpdate.Text != "" && dtTimePkUpdate.Value.Date != DateTime.Now.Date && txtDirUpdate.Text != "" && txtStudUpdate.Text != "")
                {                 
                        var updateMov = Global.entities.Movies.First(p => p.Movie_ID == selectedMovID);

                        updateMov.Title = txtTitleUpdate.Text;
                        updateMov.Release_Date = dtTimePkUpdate.Value.Date;
                        updateMov.Director = txtDirUpdate.Text;
                        updateMov.Studio = txtStudUpdate.Text;
                        updateMov.Genre = cbUpdateMov.Text;

                        Global.entities.SaveChanges();

                        RefreshData();                    
                }
                else
                {
                    MessageBox.Show("Please input all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }            
        }

        //Add User profile
        private void btnUserAdd_Click(object sender, EventArgs e)
        {            
            try
            {
                UserIDSet();   //Last validation of ID value;

                if (cbUserRole.Text != "" && txtUserID.Text != "" && txtUserName.Text != "" && txtUserFName.Text != "" && txtUserLName.Text != "" && txtUserPass.Text != "")
                {
                    User newUser = new User();

                    newUser.User_ID = userIDValue;       //Automatically set to prevent DB error
                    newUser.User_Name = txtUserName.Text;
                    newUser.First_Name = txtUserFName.Text;
                    newUser.Last_Name = txtUserLName.Text;
                    newUser.password = txtUserPass.Text;
                    newUser.Role = cbUserRole.Text;

                    Global.entities.Users.Add(newUser);
                    Global.entities.SaveChanges();

                    RefreshData();
                    UserIDSet();   //Reset of preset ID value;
                }
                else
                {
                    MessageBox.Show("Please input all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }

            ClearEntry(3);
        }

        //Update User profile
        private void btnUserUpdate_Click(object sender, EventArgs e)
        {
            try
            {                
                if (cbBxUserUpdRole.Text != "" && txtUserUpdID.Text != "" && txtUserUpdUserName.Text != "" && txtUserUpdFName.Text != "" && txtUserUpdLName.Text != "" && txtUserUpdPass.Text != "")
                {
                    User updateUser = Global.entities.Users.First(p => p.User_ID == selectedUserID);

                    updateUser.User_Name = txtUserUpdUserName.Text;
                    updateUser.First_Name = txtUserUpdFName.Text;
                    updateUser.Last_Name = txtUserUpdLName.Text;
                    updateUser.password = txtUserUpdPass.Text;
                    updateUser.Role = cbBxUserUpdRole.Text;

                    Global.entities.SaveChanges();

                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Please input all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        //Delete - (Movie / User)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataShowingMovies == true)
            {
                var deleteMov = Global.entities.Movies.First(p => p.Movie_ID == selectedMovID);
                Global.entities.Movies.Remove(deleteMov);
                Global.entities.SaveChanges();

                RefreshData();
                MovieIDSet();                        //Automatically sets ID value and locks the field
            }
            else if (dataShowingMovies == false)
            {
                var deleteUser = Global.entities.Users.First(f => f.User_ID == selectedUserID);
                Global.entities.Users.Remove(deleteUser);
                Global.entities.SaveChanges();

                RefreshData();
                UserIDSet();                        //Automatically sets ID value and locks the field
            }
            
            //Reset ID values to prevent DB error   (DO AFTER SUCCESSFULLY BUILD)            
        }
        
        //Data Grid Current Selection - populates data into the update field
        private void dataGrdAdmin_SelectionChanged(object sender, EventArgs e)
        {            
            if (dataShowingMovies == true)
            {                
                txtIDUpdate.Text = dataGrdAdmin.CurrentRow.Cells[0].Value.ToString();
                txtTitleUpdate.Text = dataGrdAdmin.CurrentRow.Cells[1].Value.ToString();
                dtTimePkUpdate.Value = Convert.ToDateTime(dataGrdAdmin.CurrentRow.Cells[2].Value);
                txtDirUpdate.Text = dataGrdAdmin.CurrentRow.Cells[3].Value.ToString();
                txtStudUpdate.Text = dataGrdAdmin.CurrentRow.Cells[4].Value.ToString();
                cbUpdateMov.Text = dataGrdAdmin.CurrentRow.Cells[5].Value.ToString();

                selectedMovID = decimal.Parse(txtIDUpdate.Text);  //Allows update to specific ID
            }
            else if(dataShowingMovies == false)
            {
                txtUserUpdID.Text = dataGrdAdmin.CurrentRow.Cells[0].Value.ToString();
                txtUserUpdUserName.Text = dataGrdAdmin.CurrentRow.Cells[1].Value.ToString();
                txtUserUpdFName.Text = dataGrdAdmin.CurrentRow.Cells[2].Value.ToString();
                txtUserUpdLName.Text = dataGrdAdmin.CurrentRow.Cells[3].Value.ToString();
                txtUserUpdPass.Text = dataGrdAdmin.CurrentRow.Cells[4].Value.ToString();
                cbBxUserUpdRole.Text = dataGrdAdmin.CurrentRow.Cells[5].Value.ToString();

                selectedUserID = decimal.Parse(txtUserUpdID.Text);  //Allows specific ID to be selected and ready for deletion
            }
        }

        //Changes DatePicker to display
        private void dtTimePkSearch_ValueChanged(object sender, EventArgs e)
        {
            if (dtTimePkSearch.Value.Date != DateTime.Now.Date)
            {
                dtTimePkSearch.Format = DateTimePickerFormat.Short;                
            }
        }

        //Changes DatePicker to display
        private void dtTimePkAdd_ValueChanged(object sender, EventArgs e)
        {
            if (dtTimePkAdd.Value.Date != DateTime.Now.Date)
            {
                dtTimePkAdd.Format = DateTimePickerFormat.Short;
            }
        }


        #endregion
    }
}
