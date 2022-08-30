using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

// * Load the text file
// * Convert the text to List<PrizeModel>
// Find the max ID
// Add the new record with the new ID
// Convert the prizes to list<string>
// Save the list<string> to the text file.

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string fullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> loadFile(this string file)
        {
            if (!File.Exists(file)) return new List<string>();
            
            return File.ReadAllLines(file).ToList();
        }

        public static List<Models.PrizeModel> convertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        public static List<PersonModel> convertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (var line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];

                output.Add(p);
            }

            return output;
        }

        public static void saveToPrizeFile(this List<PrizeModel> models,string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(fileName.fullFilePath(), lines);
        }

        public static void saveToPeopleFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellphoneNumber}");
            }

            File.WriteAllLines(fileName.fullFilePath(), lines);
        }

        public static List<TeamModel> convertToTeamModels(this List<string> lines, string peopleFileName)
        {
            //id,team name,list of ids separated by the pipe
            // 3,Tim's team,1|3|5

            List<TeamModel> output = new List<TeamModel> ();
            List<PersonModel> people = peopleFileName.fullFilePath().loadFile().convertToPersonModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamModel t = new TeamModel();
                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }
                output.Add(t);
            }

            return output;
        }

        public static List<TournamentModel> convertToTournamentModels(this List<string> lines,
            string teamFileName,
            string peopleFileName,
            string prizeFileName)
        {
            // id = 0;
            // TournamentName = 1
            // EntryFee = 2
            // EnteredTeams = 3
            // Prizes = 4
            // Rounds = 5
            //id,tournamentName,entryFee,(id|id|id - Entered Teams),(id|id|id - Prizes),(Rounds - id^id^id|id^id^id|id^id^id)
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = teamFileName.fullFilePath().loadFile().convertToTeamModels(peopleFileName);
            List<PrizeModel> prizes = prizeFileName.fullFilePath().loadFile().convertToPrizeModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TournamentModel tm = new TournamentModel();
                tm.Id = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[3].Split('|');

                foreach (string id in teamIds)
                {
                    //t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                    tm.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                string[] prizeIds = cols[4].Split('|');

                foreach (string id in prizeIds)
                {
                    tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                // TODO - Capture rounds information

                output.Add(tm);
            }

            return output;
        }

        public static void saveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel t in models)
            {
                lines.Add($"{t.Id},{t.TeamName},{convertPeopleListToString(t.TeamMembers)}");
            }

            File.WriteAllLines(fileName.fullFilePath(), lines);
        }

        public static void saveToTournamentFile(this List<TournamentModel> models,string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TournamentModel tm in models)
            {
                lines.Add($@"{tm.Id},
                            {tm.TournamentName},
                            {tm.EntryFee},
                            {convertTeamListToString(tm.EnteredTeams)},
                            {convertPrizeListToString(tm.Prizes)},
                            {""}");
            }

            File.WriteAllLines(fileName.fullFilePath(), lines);
        }

        private static string convertTeamListToString(List<TeamModel> teams)
        {
            string output = "";

            if (teams.Count == 0) return "";

            foreach (TeamModel t in teams)
            {
                output += $"{t.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string convertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";

            if (prizes.Count == 0) return "";

            foreach (PrizeModel p in prizes)
            {
                output += $"{p.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }
        // (Rounds - id^id^id|id^id^id|id^id^id)
        private static string convertRoundListToString(List<List<MatchupModel>> rounds)
        {
            string output = "";

            if (rounds.Count == 0) return "";

            foreach (List<MatchupModel> r in rounds)
            {
                output += $"{convertMatchupListToString(r)}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;
        }

        private static string convertMatchupListToString(List<MatchupModel> matchups)
        {
            string output = "";

            if (matchups.Count == 0) return output;

            foreach (MatchupModel m in matchups)
            {
                //output += $"{m.Id}^";
            }

            output = output.Substring(0, output.Length - 1);


            return output;
        }

        private static string convertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            if(people.Count == 0) return output;

            foreach (PersonModel p in people)
            {
                output += $"{p.Id}|";
            }

            output = output.Substring(0, output.Length - 1);


            return output;
        }


    }
}
