namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;

    abstract public class Recipe : IRecipe
    {
        private const string NotPositivePropertyErrorMessage = "The {0} must be positive.";

        private string name;

        private decimal price;

        private int calories;

        private int quantityPerServing;

        private MetricUnit unit;

        private int timeToPrepare;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(String.Format(NotPositivePropertyErrorMessage, "Price"));
                }

                this.price = value;
            }
        }

        public int Calories
        {
            get
            {
                return this.calories;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(String.Format(NotPositivePropertyErrorMessage, "Calories"));
                }

                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(String.Format(NotPositivePropertyErrorMessage, "QuantityPerServing"));
                }

                this.price = value;
            }
        }

        public MetricUnit Unit
        {
            get
            {
                return this.unit;
            }

            protected set
            {
                this.unit = value;
            }
        }

        public int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(String.Format(NotPositivePropertyErrorMessage, "TimeToPrepare"));
                }

                this.price = value;
            }
        }

        public Recipe(string name)
        {
            this.name = name;
        }

        public Recipe(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public Recipe(string name, decimal price, int calories)
        {
            this.name = name;
            this.price = price;
            this.Calories = calories;
        }

        public Recipe(string name, decimal price, int calories, int quantityPerServing)
        {
            this.name = name;
            this.price = price;
            this.Calories = calories;
            this.quantityPerServing = quantityPerServing;
        }

        public Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.name = name;
            this.price = price;
            this.Calories = calories;
            this.quantityPerServing = quantityPerServing;
            this.timeToPrepare = timeToPrepare;
        }

        public abstract int GetOrder();
    }
}
