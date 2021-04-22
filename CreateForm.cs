//Flora Kolikyan
//200455023

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace FinalProject
{
    //creating CreateForm
    public partial class CreateForm : Form
    {
        //creating arraylist which will store error messages from validation 
        ArrayList ErrorsList;
        //creating dataContext which helps us to connect to database
        LinqToSqlConnectionClassDataContext dataContext;
        public CreateForm()
        {
            InitializeComponent();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            //we need to add background image for our form
            //so, the first step will be adding the image in the Resources.resx. In the Resources.resx we are uploading the files that will be used in the current project
            //next step is connecting this image to this form through properties
            this.BackgroundImage = Properties.Resources.Background;
            //here we are initialize dataContext
            dataContext = new LinqToSqlConnectionClassDataContext();
        }
        // in this function we are create action which will happen when we submit button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //here we are initialize ErrorsList
            ErrorsList = new ArrayList();
            //creating check statement which will help us when we will validate 
            Boolean ValidData = true;
            //there will be validation of all textboxes
            //in the textboxes where we will expect only letters we add match with [a-zA-Z] regular expression. Which will avoid any other symbols or numeric.
            //in the textboxes where we will expect only numbers we add match with [0-9] regular expression. Which will avoid any other symbols or letters.
            //we can concat common regular expressions but as soon as we need unique error messages for each textbox we won't do that.
            if (!Regex.Match(FirstNameTextbox.Text, "^[a-zA-Z]*$").Success)
            {
                //function .Add() help us to add the new position to the arraylist
                ErrorsList.Add("First name can contain only letters");
                ValidData = false;
            }

            if (!Regex.Match(LastNameTextbox.Text, "^[a-zA-Z]*$").Success)
            {
                ErrorsList.Add("Last name can contain only letters");
                ValidData = false;
            }

            if (!Regex.Match(AgeTextbox.Text, "^[0-9]*$").Success)
            {
                ErrorsList.Add("The age can contain only numbers");
                ValidData = false;
            }
            //for this validation we also look at how many letters should be in the field
            if (PositionOnFieldTextBox.Text.Length > 3 || !Regex.Match(PositionOnFieldTextBox.Text, "^[a-zA-Z]*$").Success)
            {
                ValidData = false;
                ErrorsList.Add("The position can only contains 3 letters");
            }

            //we also need to check if the field contain anything. Bcs textboxes have string type and we don't need convert int we concat all textboxes.
            if (string.IsNullOrEmpty(FirstNameTextbox.Text) || string.IsNullOrEmpty(LastNameTextbox.Text) || string.IsNullOrEmpty(CountryTextbox.Text) || string.IsNullOrEmpty(AgeTextbox.Text) || string.IsNullOrEmpty(MatchesAmountTextbox.Text) || string.IsNullOrEmpty(GoalsTextbox.Text) || string.IsNullOrEmpty(AssistsTextbox.Text) || string.IsNullOrEmpty(TeamTextbox.Text) || string.IsNullOrEmpty(NumberTextbox.Text) || string.IsNullOrEmpty(PositionOnFieldTextBox.Text))
            {
                ValidData = false;
                ErrorsList.Add("The fields can't be empty!");
            }
            //the last validation is checking if the ValidDate is false or true
            //if false 
            if (ValidData == false)
            {
                //cerating StringBuilder object which saving the stored error messages that created before
                StringBuilder builder = new StringBuilder();
                //itterating though all arrylist
                foreach (string element in ErrorsList)
                {
                    //function .Append help us to gather all messages together
                    builder.Append(element);
                    builder.Append("\n");
                }
                //here we call message box with all errors from validation
                MessageBox.Show(builder.ToString());
                //function .Clear() will delete previous errors messages from previous validation.
                ErrorsList.Clear();
            }
            else {

                players_statistic plstat = new players_statistic();

                plstat.player_first_name = FirstNameTextbox.Text;
                plstat.player_last_name = LastNameTextbox.Text;
                plstat.country_of_birth = CountryTextbox.Text;
                plstat.player_age = int.Parse(AgeTextbox.Text);
                plstat.assists_made = int.Parse(AssistsTextbox.Text);
                plstat.goals_scored = int.Parse(GoalsTextbox.Text);
                plstat.player_number = int.Parse(NumberTextbox.Text);
                plstat.matches_played = int.Parse(MatchesAmountTextbox.Text);
                plstat.player_team = TeamTextbox.Text;
                plstat.position_on_field = PositionOnFieldTextBox.Text;

                dataContext.players_statistics.InsertOnSubmit(plstat);

                dataContext.SubmitChanges();

                this.Hide();
                var menu = new MainMenu();
                //open main menu
                menu.ShowDialog();
                this.Close();


            }
            
        }

    }
}
