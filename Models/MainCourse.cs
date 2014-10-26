namespace RestaurantManager.Models
{
    using RestaurantManager.Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
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
    }
}
