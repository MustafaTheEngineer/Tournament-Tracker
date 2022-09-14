using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string prizesFile = "PrizeModel.csv";
        private const string peopleFile = "PeopleModel.csv";
        private const string teamFile = "TeamModels.csv";
        private const string tournamentFile = "TournamentModels.csv";
        private const string matchupFile = "MatchupModels.csv";
        private const string matchupEntryFile = "MatchupEntryModels.csv";

        public PersonModel createPerson(PersonModel model)
        {
            List<PersonModel> people = GlobalConfig.peopleFile.fullFilePath().loadFile().convertToPersonModels();

            int currentId = 1;
            if (people.Count > 0)
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;

            model.Id = currentId;

            people.Add(model);
            people.saveToPeopleFile(peopleFile);

            return model;
        }

        // TODO - Wire up the createPrize for text files
        public PrizeModel createPrize(PrizeModel model)
        {
            // * Load the text file
            // * Convert the text to List<PrizeModel>
            List<PrizeModel> prizes = GlobalConfig.prizesFile.fullFilePath().loadFile().convertToPrizeModels();

            // Find the max ID
            int currentId = 1;
            if(prizes.Count > 0)
                    currentId = currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;

            model.Id = currentId;

            // Add the new record with the new ID (max + 1)
            prizes.Add(model);

            // Convert the prizes to list<string>
            // Save the list<string> to the text file.
            prizes.saveToPrizeFile("PrizeModel.csv");

            return model;
        }

        public List<PersonModel> getPersonAll()
        {
            return GlobalConfig.peopleFile.fullFilePath().loadFile().convertToPersonModels();
        }

        public TeamModel createTeam(TeamModel model)
        {
            List<TeamModel> teams = GlobalConfig.teamFile.fullFilePath().loadFile().convertToTeamModels(GlobalConfig.peopleFile);

            int currentId = 1;
            if (teams.Count > 0)
                currentId = currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;

            model.Id = currentId;

            teams.Add(model);

            teams.saveToTeamFile(GlobalConfig.teamFile);

            return model;
        }

        public List<TeamModel> getTeamAll()
        {
            return GlobalConfig.teamFile.fullFilePath().loadFile().convertToTeamModels(GlobalConfig.peopleFile);
        }

        public void createTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = tournamentFile
                .fullFilePath()
                .loadFile()
                .convertToTournamentModels(GlobalConfig.teamFile, GlobalConfig.peopleFile, GlobalConfig.prizesFile);

            int currentId = 1;

            if (tournaments.Count > 0) currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;

            model.Id = currentId;

            model.saveRoundsToFile(GlobalConfig.matchupFile, GlobalConfig.matchupEntryFile);

            tournaments.Add(model);

            tournaments.saveToTournamentFile(tournamentFile);
        }

        public List<TournamentModel> getTournamentAll()
        {
            return tournamentFile
                .fullFilePath()
                .loadFile()
                .convertToTournamentModels(GlobalConfig.teamFile, GlobalConfig.peopleFile, GlobalConfig.prizesFile);
        }

        public void updateMatchup(MatchupModel model)
        {
            model.updateMatchupToFile();
        }
    }
}
