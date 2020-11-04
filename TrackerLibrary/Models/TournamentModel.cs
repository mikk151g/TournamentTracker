using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TournamentModel
    {
        #region Fields

        private int _id;
        private string _tournamentName;
        private decimal _entryFee;
        private List<TeamModel> _enteredTeams = new List<TeamModel>();
        private List<PrizeModel> _prizes = new List<PrizeModel>();
        private List<List<MatchupModel>> _rounds = new List<List<MatchupModel>>();

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for tournament.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Represents the name of the tournament.
        /// </summary>
        public string TournamentName
        {
            get { return _tournamentName; }
            set { _tournamentName = value; }
        }

        /// <summary>
        /// Represents the payment for entering 
        /// the tournament.
        /// </summary>
        public decimal EntryFee
        {
            get { return _entryFee; }
            set { _entryFee = value; }
        }

        /// <summary>
        /// Represents which teams are participating 
        /// in the tournament.
        /// </summary>
        public List<TeamModel> EnteredTeams
        {
            get { return _enteredTeams; }
            set { _enteredTeams = value; }
        }

        /// <summary>
        /// Represents which prizes the tournament has.
        /// </summary>
        public List<PrizeModel> Prizes
        {
            get { return _prizes; }
            set { _prizes = value; }
        }

        /// <summary>
        /// Reprents which round the tournament 
        /// is currently in.
        /// </summary>
        public List<List<MatchupModel>> Rounds
        {
            get { return _rounds; }
            set { _rounds = value; }
        }

        #endregion
    }
}
