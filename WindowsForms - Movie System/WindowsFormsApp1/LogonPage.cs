using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LogonPage : Form
    {
        public LogonPage()
        {
            InitializeComponent();
        }

        private void LogonPage_Load(object sender, EventArgs e)
        {
            //Instantiate the Global DB call
            Global.entities = new Movie_LogEntities();

            var movTitle = (from Movie_Log in Global.entities.Movies
                            select Movie_Log).FirstOrDefault();

            var movTitle2 = Global.entities.Movies.First(p => p.Movie_ID == 1019);

            rTxtBxNewRel.AppendText("\nTitle: " + movTitle.Title + "\nGenre: " + movTitle.Genre + "\nMovie ID: " + movTitle.Movie_ID);
            rTxtBxNewRel.AppendText("\n\nTitle: " + movTitle2.Title + "\nGenre: " + movTitle2.Genre + "\nMovie ID: " + movTitle2.Movie_ID);
            rTxtBxNewRel.ReadOnly = true;
            txtBxPwd.UseSystemPasswordChar = true;  //Hides User password entry
        }

        #region Event Handler

        //Log-in Button - Checks for User or Admin rights
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string userN = txtBxUserN.Text;
            string pass = txtBxPwd.Text;

            var userEntry = (from User in Global.entities.Users
                             where User.User_Name == userN && User.password == pass
                             select User).FirstOrDefault();

            if (userEntry != null)
            {
                if (userEntry.Role == "Admin")
                {
                    Global.userID = userEntry.User_ID;
                    Global.userName = userEntry.First_Name + " " + userEntry.Last_Name;     //Saves User name

                    this.Hide();
                    Bloc_Buster_Form formAdmin = new Bloc_Buster_Form();
                    formAdmin.Show();
                }
                else if (userEntry.Role == "User")
                {
                    Global.userID = userEntry.User_ID;
                    Global.userName = userEntry.First_Name + " " + userEntry.Last_Name;     //Saves User name

                    this.Hide();
                    UserLanding formUser = new UserLanding();
                    formUser.Show();
                }
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password.  Please re-enter.");
            }
            #endregion
        }
    }
}
