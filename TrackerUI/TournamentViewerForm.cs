using System.ComponentModel;
using TrackerLibrary;
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

            wireUpLists();

            loadFormData();
            loadRounds();
        }

        private void loadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void wireUpLists()
        {
            roundDropDown.DataSource = rounds;
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "displayName";
        }

        private void loadRounds()
        {
            rounds.Clear();

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
            loadMatchups(1);
        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMatchups((int) roundDropDown.SelectedItem);
        }

        private void loadMatchups(int round)
        {
            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || !unplayedOnlyCheckBox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }
                    break;
                }
            }

            if(selectedMatchups.Count > 0)
            {
                loadMatchup(selectedMatchups.First());
            }

            displayMatchupInfo();
        }

        private void displayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);
            
            teamOneName.Visible = isVisible;
            teamOneScoreLabel.Visible = isVisible;
            teamOneScoreValue.Visible = isVisible;
            teamTwoName.Visible = isVisible;
            teamTwoScoreLabel.Visible = isVisible;
            teamTwoScoreValue.Visible = isVisible;
            versusLabel.Visible = isVisible;
            scoreButton.Visible = isVisible;
        }

        private void loadMatchup(MatchupModel m)
        {   
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
            loadMatchup((MatchupModel) matchupListBox.SelectedItem);
        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            loadMatchups((int) roundDropDown.SelectedItem);
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            if (m != null)
            {
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeting == null)
                            teamOneName.Text = "Not determined yet";
                        else if (m.Entries[0] != null)
                        {
                            bool scoreValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);

                            if (scoreValid)
                                m.Entries[0].Score = teamOneScore;
                            else
                            {
                                MessageBox.Show("Please enter a valid score for team 1");
                                return;
                            }
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
                            bool scoreValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

                            if (scoreValid)
                                m.Entries[1].Score = teamTwoScore;
                            else
                            {
                                MessageBox.Show("Please enter a valid score for team 2");
                                return;
                            }
                        }
                    }
                }

                if (teamOneScore > teamTwoScore)    m.Winner = m.Entries[0].TeamCompeting;
                else if(teamOneScore < teamTwoScore)    m.Winner = m.Entries[1].TeamCompeting;
                else    MessageBox.Show("I do not handle tie games");

                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntryModel me in rm.Entries)
                        {
                            if (me.ParentMatchup != null)
                            {
                                if (me.ParentMatchup.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connection.updateMatchup(rm);
                                }
                            }
                        }
                    }
                }
                
                loadMatchups((int)roundDropDown.SelectedItem);

                GlobalConfig.Connection.updateMatchup(m);
            }
        }

        private void teamOneScoreValue_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}