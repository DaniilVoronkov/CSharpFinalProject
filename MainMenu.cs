// Made by: Daniil Voronkov 
// Student number: 200473393

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class MainMenu : Form
    {
        LinqToSqlConnectionClassDataContext dataContext;
        
        public MainMenu()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
             CreateForm create = new CreateForm();
            this.Hide();
            create.ShowDialog();
            this.Close();
        }

        //function that triggers when we press on the 'close' button
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //function that triggers when we press on the cell of the data grid view
        private void playersTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if we pressed on the goals column - do following:
            if(playersTable.CurrentCell.ColumnIndex == 5) 
            {
                //if the goals value is bigger than 0
                if(int.Parse(playersTable.CurrentCell.Value.ToString()) > 0)
                {
                    //showing the message box with the count of average goals per season
                    MessageBox.Show("Average goals scored per current season: " +  double.Parse(playersTable.CurrentCell.Value.ToString())/38);
                }
                //if the amount of goals is 0 - do following:
                else
                {
                    //showing the message box, that tells that the current season average is 0
                    MessageBox.Show("Average goals scored per current season: 0");
                }
            }
            //if we pressed on the assists column - do following:
            if (playersTable.CurrentCell.ColumnIndex == 6)
            {
                //if the assists value is bigger than 0
                if (int.Parse(playersTable.CurrentCell.Value.ToString()) > 0)
                {
                    //showing the message box with the count of average assists per season
                    MessageBox.Show("Average assists made per current season: " + double.Parse(playersTable.CurrentCell.Value.ToString()) / 38);
                }
                //if the amount of assists is 0 - do following:
                else
                {
                    //showing the message box, that tells that the current season average is 0
                    MessageBox.Show("Average assists made per current season: 0");
                }
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //prevents user from creating rows right in the table
            playersTable.AllowUserToAddRows = false;
            //setting the background
            this.BackgroundImage = Properties.Resources.Background;
            //initializing data context
            dataContext = new LinqToSqlConnectionClassDataContext();
            //filling the data grid with the data from the players_statistics table
            playersTable.DataSource = dataContext.players_statistics;
        }

        //function that triggers when we hover on any button
        private void allButtons_MouseEnter(object sender, EventArgs e)
        {
            //defining on which button we hovered
            Button btn = (Button)sender;
            //changing the background color of the button
            btn.BackColor = Color.Black;
            //changing the font color of the button
            btn.ForeColor = Color.White;
        }

        //function that triggers when mouse leaves the button area
        private void allButtons_MouseLeave(object sender, EventArgs e)
        {
            //defining on which button we hovered
            Button btn = (Button)sender;
            //changing back the background color of the button
            btn.BackColor = Color.Khaki;
            //changing back the font color of the button
            btn.ForeColor = Color.Black;
        }

        //function that triggers when we press on the delete button
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //showing the confirmation box (with yes/no answers)
            var confirmationMessage = MessageBox.Show("Do you want to delete this row?", "Confirm your action!", MessageBoxButtons.YesNo);

            //if user pressed yes - do following
            if (confirmationMessage == DialogResult.Yes)
            {
                //deleting the current row
                playersTable.Rows.RemoveAt(playersTable.CurrentCell.RowIndex);
                //submitting changes in our database
                dataContext.SubmitChanges();
            }
        }

        //function that triggers when we press on the edit button
        private void editButton_Click(object sender, EventArgs e)
        {
            /* EditForm edit = new EditForm(from rowForEdit in dataContext.players_statistics
            where rowForEdit.player_id == playersTable.CurrentCell.RowIndex + 1
                             select rowForEdit;); 
            this.Hide();
            edit.ShowDialog();
            this.Close(); */
        }
    }
}
