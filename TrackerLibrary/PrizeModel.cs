using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        #region Fields

        private int _id;
        private int _placeNumber;
        private string _placeName;
        private decimal _prizeAmount;
        private double _prizePercentage;

        #endregion

        #region Properties

        /// <summary>
        /// Unique identifier for prizes.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value;  }
        }

        /// <summary>
        /// Represents which place the prize 
        /// belongs to.
        /// </summary>
        public int PlaceNumber
        {
            get { return _placeNumber; }
            set { _placeNumber = value; }
        }

        /// <summary>
        /// Represents what the place is called.
        /// </summary>
        public string PlaceName
        {
            get { return _placeName; }
            set { _placeName = value; }
        }

        /// <summary>
        /// Represents how big the prize is 
        /// in dollars.
        /// </summary>
        public decimal PrizeAmount
        {
            get { return _prizeAmount; }
            set { _prizeAmount = value; }
        }

        /// <summary>
        /// Represents how much in percent the 
        /// place gets from the price pool.
        /// </summary>
        public double PrizePercentage
        {
            get { return _prizePercentage; }
            set { _prizePercentage = value; }
        }

        #endregion

        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}