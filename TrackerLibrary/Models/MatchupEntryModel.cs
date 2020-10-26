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

        private TeamModel _teamCompeting;
        private double _score;
        private MatchupModel _parentMatchup;

        #endregion

        #region Properties

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
