using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_EditForm
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext dc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // set background image for panel
            this.BackgroundImage = Properties.Resources.Background;

            dc = new DataClasses1DataContext();
            dataGridView1.DataSource = dc.Players;
        }

        // function to load the text fields with chosen record to edit
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var currPlayer = (from p in dc.Players
                              where p.PlayerID == dataGridView1.CurrentCell.RowIndex + 1
                              select p).ToArray();

            // fill in the text fields; array onoly has 1 record with index 0
            textBox1.Text = currPlayer[0].FirstName;
            textBox2.Text = currPlayer[0].LastName;
            textBox3.Text = currPlayer[0].CountryOfBirth;
            textBox4.Text = currPlayer[0].Age.ToString();
            textBox5.Text = currPlayer[0].GoalsScored.ToString();
            textBox6.Text = currPlayer[0].AssistsMade.ToString();
            textBox7.Text = currPlayer[0].PlayerNumber.ToString();
            textBox8.Text = currPlayer[0].PlayerTeam;
            textBox9.Text = currPlayer[0].MatchesPlayed.ToString();
            textBox10.Text = currPlayer[0].PositionOnField;
        }

        // button to submit any changes in the text fields
        private void button1_Click(object sender, EventArgs e)
        {

            // validate text fields for empty or null data and pop up message if any empty
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text) ||
                string.IsNullOrEmpty(textBox7.Text) ||
                string.IsNullOrEmpty(textBox8.Text) ||
                string.IsNullOrEmpty(textBox9.Text) ||
                string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else if (!Regex.Match(textBox1.Text, "^[a-zA-Z]*$").Success ||
                    !Regex.Match(textBox2.Text, "^[a-zA-Z]*$").Success)
            {
                MessageBox.Show("First and last name have to contain characters only.");
            }
            else if (!Regex.Match(textBox4.Text, "[0-9]*$").Success ||
                !Regex.Match(textBox5.Text, "[0-9]*$").Success ||
                !Regex.Match(textBox6.Text, "[0-9]*$").Success ||
                !Regex.Match(textBox7.Text, "[0-9]*$").Success ||
                !Regex.Match(textBox9.Text, "[0-9]*$").Success )
            {
                MessageBox.Show("Age, Goals, Assists, Player Number, and Matches Played must be integers");
            }
            // if all validation passes, submit the data to the database
            else
            {
                var CurrentUserInfo = from p in dc.Players
                                      where p.PlayerID == dataGridView1.CurrentCell.RowIndex + 1
                                      select p;

                foreach (Player updatedPlayer in CurrentUserInfo)
                {
                    //Player updatedPlayer = new Player();
                    updatedPlayer.FirstName = textBox1.Text;
                    updatedPlayer.LastName = textBox2.Text;
                    updatedPlayer.CountryOfBirth = textBox3.Text;
                    updatedPlayer.Age = int.Parse(textBox4.Text);
                    updatedPlayer.GoalsScored = int.Parse(textBox5.Text);
                    updatedPlayer.AssistsMade = int.Parse(textBox6.Text);
                    updatedPlayer.PlayerNumber = int.Parse(textBox7.Text);
                    updatedPlayer.PlayerTeam = textBox8.Text;
                    updatedPlayer.MatchesPlayed = int.Parse(textBox9.Text);
                    updatedPlayer.PositionOnField = textBox10.Text;

                }

                //dc.Players.InsertOnSubmit(updatedPlayer);
                dc.SubmitChanges();

                // dataGridView1.DataSource = dc.Players;

                this.Hide();
                //open main menu
                var menu = new MainMenu();
                menu.ShowDialog();
                this.Close();

            }

        }

        // button to return to main menu (cancel without changes)
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            var MainMenuForm = new MainMenu();
            MainMenuForm.Show();
        }

        // button to close the app
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
