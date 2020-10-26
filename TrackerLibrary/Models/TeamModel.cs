using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        #region Fields

        private List<PersonModel> _teamMembers = new List<PersonModel>();
        private string _teamName;

        #endregion

        #region Properties

        /// <summary>
        /// Represents the members/persons on the team.
        /// </summary>
        public List<PersonModel> TeamMembers
        {
            get { return _teamMembers; }
            set { _teamMembers = value; }
        }

        /// <summary>
        /// Represents the name of the team.
        /// </summary>
        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }

        #endregion
    }
}
