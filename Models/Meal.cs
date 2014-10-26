namespace RestaurantManager.Models
{
    using RestaurantManager.Interfaces;

    abstract public class Meal: Recipe, IMeal
    {
        private bool vegan;

        public bool IsVegan
        {
            get
            {
                return vegan;
            }

            protected set
            {
                this.vegan = value;
            }
        }

        /**
         * Turns "vegan" to "not vegan" and vice versa
         */
        public virtual void ToggleVegan()
        {
            this.vegan = !this.vegan;
        }

        public Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.Unit = MetricUnit.Grams;
        }

        protected string GetUnitToString()
        {
            return "g";
        }
    }
}
