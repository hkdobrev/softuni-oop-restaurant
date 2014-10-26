namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;

    public class Salad : Meal, ISalad
    {
        private const string InvalidToggleVeganOperationMessage = "A Salad is always vegan.";

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
    }
}
