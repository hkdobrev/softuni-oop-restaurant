namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;

    public class Drink : Recipe, IDrink
    {
        private const int MaximumCalories = 100;

        private const string TooMuchCaloriesErrorMessage = "Calories in drinks must not exceed {0} calories. {1} given.";

        // In minutes
        private const int MaximumTimeToPrepare = 20;

        private const string TooMuchTimeToPrepareErrorMessage = "Time to prepare a drink must not exceed {0}. {1} given.";

        private bool carbonated;

        public bool IsCarbonated
        {
            get
            {
                return this.carbonated;
            }
        }

        public new int Calories
        {
            get
            {
                return base.Calories;
            }

            private set
            {
                if (value > MaximumCalories)
                {
                    throw new ArgumentOutOfRangeException(String.Format(TooMuchCaloriesErrorMessage, MaximumCalories, value));
                }

                base.Calories = value;
            }
        }

        public new int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }

            private set
            {
                if (value > MaximumTimeToPrepare)
                {
                    throw new ArgumentOutOfRangeException(String.Format(TooMuchTimeToPrepareErrorMessage, MaximumTimeToPrepare, value));
                }

                base.TimeToPrepare = value;
            }
        }

        internal Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.carbonated = isCarbonated;
            this.Unit = MetricUnit.Milliliters;
        }
    }
}
