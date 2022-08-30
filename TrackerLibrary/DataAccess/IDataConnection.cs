using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel createPrize(PrizeModel model);
        PersonModel createPerson(PersonModel model);
        List<PersonModel> getPersonAll();
        TeamModel createTeam(TeamModel model);
        List<TeamModel> getTeamAll();
        void createTournament(TournamentModel model);
    }
}
