namespace RestaurantManager.Engine.Factories
{
    using System;
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;

    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
