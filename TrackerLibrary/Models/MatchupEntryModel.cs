using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        #region Fields

        private int _id;
        private int _teamCompetingId;
        private TeamModel _teamCompeting;
        private double _score;
        private int _parentMatchupId;
        private MatchupModel _parentMatchup;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for matchup entry.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// The unique identifier for the team
        /// </summary>
        public int TeamCompetingId
        {
            get { return _teamCompetingId; }
            set { _teamCompetingId = value; }
        }

        /// <summary>
        /// Represents one of the teams in a matchup.
        /// </summary>
        public TeamModel TeamCompeting
        {
            get { return _teamCompeting; }
            set { _teamCompeting = value; }
        }

        /// <summary>
        /// Represents the team's score.
        /// </summary>
        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        /// <summary>
        /// The unique identifier for the parent matchup (team).
        /// </summary>
        public int ParentMatchupId
        {
            get { return _parentMatchupId; }
            set { _parentMatchupId = value; }
        }

        /// <summary>
        /// Represents the matchup that this team came 
        /// from as the winner.
        /// </summary>
        public MatchupModel ParentMatchup
        {
            get { return _parentMatchup; }
            set { _parentMatchup = value; }
        }

        #endregion
    }
}
