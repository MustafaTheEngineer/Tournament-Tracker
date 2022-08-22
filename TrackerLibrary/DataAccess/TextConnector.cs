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

        public PersonModel createPerson(PersonModel model)
        {
            List<PersonModel> people = peopleFile.fullFilePath().loadFile().convertToPersonModels();

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
            List<PrizeModel> prizes = prizesFile.fullFilePath().loadFile().convertToPrizeModels();

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
            return peopleFile.fullFilePath().loadFile().convertToPersonModels();
        }
    }
}
