namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;

    public class Dessert : Meal, IDessert
    {
        private const int Order = 40;

        private const string ToStringFormat = "{0}{1}== {2} == ${3}\nPer serving: {4} {5}, {6} kcal\nReady in {7} minutes";

        private bool withSugar = true;

        public bool WithSugar
        {
            get
            {
                return this.withSugar;
            }
        }

        /**
         * Turns "with sugar" to "without sugar" and vice versa
         */
        public void ToggleSugar()
        {
            this.withSugar = !this.withSugar;
        }

        public Dessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public override int GetOrder()
        {
            return Order;
        }

        public override string ToString()
        {
            return String.Format(
                ToStringFormat,
                this.withSugar ? "" : "[NO SUGAR] ",
                this.IsVegan ? "[VEGAN] " : "",
                this.Name,
                this.Price,
                this.QuantityPerServing,
                this.GetUnitToString(),
                this.Calories,
                this.TimeToPrepare
            );
        }
    }
}
