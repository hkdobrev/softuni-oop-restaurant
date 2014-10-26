namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        private const int Order = 30;

        private const string ToStringFormat = "{0}== {1} == ${2}\nPer serving: {3} {4}, {5} kcal\nReady in {6} minutes\nType: {7}";

        private MainCourseType type;

        public MainCourseType Type
        {
            get
            {
                return this.type;
            }
        }

        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, MainCourseType type)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.type = type;
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
                this.Type.ToString()
            );
        }
    }
}
