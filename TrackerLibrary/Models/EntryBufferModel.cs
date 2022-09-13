using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class EntryBufferModel
    {
        public int Id { get; set; }
        /// <summary>
        /// The unique identifier for the team.
        /// </summary>>
        public int TeamCompetingId { get; set; }
        /// <summary>
        /// Represents the score for this particular team
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// The unique identifier for the parent matchup (team).
        /// </summary>
        public double ParentMatchupId { get; set; }
    }
}
