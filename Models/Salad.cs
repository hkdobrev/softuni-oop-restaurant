namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;

    public class Salad : Meal, ISalad
    {
        private const int Order = 20;

        private const string InvalidToggleVeganOperationMessage = "A Salad is always vegan.";

        private const string ToStringFormat = "{0}== {1} == ${2}\nPer serving: {3} {4}, {5} kcal\nReady in {6} minutes\nContains pasta: {7}";

        private bool containsPasta;

        public bool ContainsPasta
        {
            get
            {
                return this.containsPasta;
            }
        }

        public override void ToggleVegan()
        {
            throw new InvalidOperationException(InvalidToggleVeganOperationMessage);
        }

        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.containsPasta = containsPasta;
            this.IsVegan = false;
        }

        public override int GetOrder()
        {
            return Order;
        }

        public override string ToString()
        {
            return String.Format(
                ToStringFormat,
                this.IsVegan ? "[VEGAN] " : "",
                this.Name,
                this.Price,
                this.QuantityPerServing,
                this.GetUnitToString(),
                this.Calories,
                this.TimeToPrepare,
                this.ContainsPasta ? "yes" : "no"
            );
        }
    }
}
