using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MovieRepository__ClassLibrary;   //Referencing the seperate file "MovieRepository"

namespace WindowsForms___Movie_System
{
    public partial class Bloc_Buster_Form : Form
    {
        //Movies movies;

        public Bloc_Buster_Form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Menu Options - File (Exit) , Change User (User, Admin)
        #region Menu Options
        //Exit Function
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Change User - User Menu
        private void userPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Change User - Admin Menu
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
