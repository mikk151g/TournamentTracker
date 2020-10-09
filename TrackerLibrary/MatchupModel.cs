using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents one match in the tournament.
    /// </summary>
    public class MatchupModel
    {
        #region Fields

        private List<MatchupEntryModel> _entries = new List<MatchupEntryModel>();
        private TeamModel _winner;
        private int _matchupRound;

        #endregion

        #region Properties

        /// <summary>
        /// Represents the two teams in this matchup
        /// </summary>
        public List<MatchupEntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        /// <summary>
        /// Winner of the match.
        /// </summary>
        public TeamModel Winner
        {
            get { return _winner; }
            set { _winner = value; }
        }

        /// <summary>
        /// What round the matchup is in.
        /// </summary>
        public int MatchupRound
        {
            get { return _matchupRound; }
            set { _matchupRound = value; }
        }

        #endregion
    }
}
