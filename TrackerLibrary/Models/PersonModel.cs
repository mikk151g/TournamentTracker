using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        #region Fields

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _cellphoneNumber;
        private string _fullName;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for person.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Represents the first name of the person.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Represents the last name of the person.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Represents the person's email address.
        /// </summary>
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        /// <summary>
        /// Represents the person's phone number.
        /// </summary>
        public string CellphoneNumber
        {
            get { return _cellphoneNumber; }
            set { _cellphoneNumber = value; }
        }

        public string FullName
        {
            get 
            { 
                return $"{ FirstName } { LastName }";
            }
        }

        #endregion
    }
}
