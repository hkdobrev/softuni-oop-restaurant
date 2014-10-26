namespace RestaurantManager.Models
{
    using RestaurantManager.Interfaces;

    public class Dessert : Meal, IDessert
    {
        private bool withSugar;

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
    }
}
