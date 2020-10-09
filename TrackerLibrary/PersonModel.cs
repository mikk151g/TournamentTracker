﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PersonModel
    {
        #region Fields

        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private string _cellphoneNumber;

        #endregion

        #region Properties

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

        #endregion
    }
}
