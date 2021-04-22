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
            /* createForm create = new createForm(); */
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(playersTable.CurrentCell.ColumnIndex == 5) 
            {
                if(int.Parse(playersTable.CurrentCell.Value.ToString()) > 0)
                {
                    MessageBox.Show("Average goals scored per current season: " +  double.Parse(playersTable.CurrentCell.Value.ToString())/38);
                }
                else
                {
                    MessageBox.Show("Average goals scored per current season: 0");
                }
            }

            if (playersTable.CurrentCell.ColumnIndex == 6)
            {
                if (int.Parse(playersTable.CurrentCell.Value.ToString()) > 0)
                {
                    MessageBox.Show("Average assists made per current season: " + double.Parse(playersTable.CurrentCell.Value.ToString()) / 38);
                }
                else
                {
                    MessageBox.Show("Average assists made per current season: 0");
                }
            }

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            playersTable.AllowUserToAddRows = false;
            this.BackgroundImage = Properties.Resources.Background;
            dataContext = new LinqToSqlConnectionClassDataContext();
            playersTable.DataSource = dataContext.players_statistics;
        }
        //allButtons_MouseEnter

        private void allButtons_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
        }

        private void allButtons_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Khaki;
            btn.ForeColor = Color.Black;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirmationMessage = MessageBox.Show("Do you want to delete this row?", "Confirm your action!", MessageBoxButtons.YesNo);

            if (confirmationMessage == DialogResult.Yes)
            {

                //query that returns all the data from the row we selected
                //dataGridView1.CurrentCell.RowIndex + 1 because row counts from 0 and id in our database starts from 1
      /*          var remove = from rowForRemoval in dataContext.players_statistics
                             where rowForRemoval.player_id == playersTable.CurrentCell.RowIndex + 1
                             select rowForRemoval; */

                
                playersTable.Rows.RemoveAt(playersTable.CurrentCell.RowIndex);
                //iterating through the result
                /*  foreach (var detail in remove)
                  {
                      //deleting every column of data from the row we want to remove
                      dataContext.players_statistics.DeleteOnSubmit(detail);
                  } */
                //implementing the changes in our database
                dataContext.SubmitChanges();
                this.Hide();
                
               MainMenu menuRefreshed = new MainMenu();
                menuRefreshed.ShowDialog();
                this.Dispose();
              //  menuRefreshed.Show();
               
                
                
             /*   MainMenu menuRefreshed = new MainMenu();
                menuRefreshed.Show(); */
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            /* editForm edit = new editForm(from rowForEdit in dataContext.players_statistics
            where rowForEdit.player_id == playersTable.CurrentCell.RowIndex + 1
                             select rowForEdit;); */
        }
    }
}
