using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary.Models;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.getPersonAll();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        private ITeamRequester callingForm;
        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();

            callingForm = caller;

           // createSampleData();

            wireUpLists();
        }

        private void createSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Esat", LastName = "Çaldır" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Kutlay", LastName = "Çaldır" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Azer", LastName = "Bülbül" });
        }

        private void wireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }
        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                PersonModel p = new PersonModel();
                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = cellPhoneValue.Text;

                p = GlobalConfig.Connection.createPerson(p);

                selectedTeamMembers.Add(p);
                wireUpLists();

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellPhoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("You need to fill all the fields except cellphone.");
            }
        }

        private bool validateForm()
        {
            // TODO - Add validation to the form.

            if (firstNameValue.Text.Length == 0 || lastNameValue.Text.Length == 0
                || emailValue.Text.Length == 0) return false;

            return true;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel) selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                wireUpLists();
            }
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel) teamMembersListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                wireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();
            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.createTeam(t);

            callingForm.teamComplete(t);
            this.Close();
        }
    }
}
