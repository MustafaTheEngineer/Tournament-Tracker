using System.ComponentModel;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournament)
        {
            InitializeComponent();
            this.tournament = tournament;

            wireUpMatchupsLists();
            wireUpMatchupsLists();

            loadFormData();
            loadRounds();
        }

        private void loadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void wireUpRoundsLists()
        {
            //roundDropDown.DataSource = null;
            roundDropDown.DataSource = rounds;
        }

        private void wireUpMatchupsLists()
        {
            //matchupListBox.DataSource = null;
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "displayName";
        }

        private void loadRounds()
        {
            rounds = new BindingList<int>();

            rounds.Add(1);
            int currRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if(matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);
                }
            }
            //roundsBinding.ResetBindings(false);
            //wireUpRoundsLists();
        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMatchups();
        }

        private void loadMatchups()
        {
            int round = (int) roundDropDown.SelectedItem;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups = new BindingList<MatchupModel>(matchups);
                }
            }
            //matchupsBinding.ResetBindings(false);
            //wireUpMatchupsLists();
        }

        private void loadMatchup()
        {
            MatchupModel m = (MatchupModel) matchupListBox.SelectedItem;
            
            if(m != null)
            {
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeting == null)
                            teamOneName.Text = "Not determined yet";
                        else if (m.Entries[0] != null)
                        {
                            teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                            teamOneScoreValue.Text = m.Entries[0].Score.ToString();

                            teamTwoName.Text = "<bye>";
                            teamTwoScoreValue.Text = "0";
                        }
                        else
                        {
                            teamOneName.Text = "Not set yet";
                            teamOneScoreValue.Text = "0";
                        }
                    }

                    if (i == 1)
                    {
                        if (m.Entries[0].TeamCompeting == null)
                            teamTwoName.Text = "Not determined yet";
                        else if (m.Entries[1] != null)
                        {
                            teamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                            teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                        }
                        else
                        {
                            teamTwoName.Text = "Not set yet";
                            teamTwoScoreValue.Text = "";
                        }
                    }
                }
            }
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMatchup();
        }
    }
}