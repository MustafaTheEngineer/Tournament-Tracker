using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentTour : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.getTeamAll();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentTour()
        {
            InitializeComponent();

            wireUpLists();
        }

        private void wireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }

        private void CreateTournamentTour_Load(object sender, EventArgs e)
        {

        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel) selectTeamDropDown.SelectedItem;

            if(t != null)
            {
                availableTeams.Remove(t);
                selectedTeams.Add(t);

                wireUpLists();
            }
        }

        private void createPrize_Click(object sender, EventArgs e)
        {
            // Call the createPrizeForm
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();
        }

        public void prizeComplete(PrizeModel model)
        {
            // Get back from the form a PrizeModel
            // Take the PrizeModel and put it into our list of selected prizes.
            selectedPrizes.Add(model);
            wireUpLists();
        }

        public void teamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            wireUpLists();
        }

        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }

        private void removeSelectedPlayersButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel) tournamentTeamsListBox.SelectedItem;

            if(t != null)
            {
                selectedTeams.Remove(t);
                availableTeams.Add(t);

                wireUpLists();
            }
        }

        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel) prizesListBox.SelectedItem;

            if(p != null) selectedPrizes.Remove(p);

            wireUpLists();
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            // TODO - Validate data
            decimal fee = 0;
            bool feeAcceptable = decimal.TryParse(entryFeeValue.Text, out fee);

            if (!feeAcceptable)
            {
                MessageBox.Show("You need to enter a valid entry fee.", "Invalid Fee", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO - create our tournament model
            TournamentModel tm = new TournamentModel();
            tm.TournamentName = tournamentNameValue.Text;
            tm.EntryFee = fee;

            tm.Prizes = selectedPrizes;
            tm.EnteredTeams = selectedTeams;

            // TODO - create our matchups
            // TODO - Create tournament entry
            // TODO - create all of the prizes entries
            // TODO - create all of team entries
            GlobalConfig.Connection.createTournament(tm);

            
        }
    }
}
