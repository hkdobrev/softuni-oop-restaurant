namespace RestaurantManager.Models
{
    using System;
    using RestaurantManager.Interfaces;
    using System.Collections.Generic;

    public class Restaurant : IRestaurant
    {
        private const string NullOrEmptyErrorMessage = "The {0} is required.";

        private const string MenuHeader = "***** {0} - {1} *****\n{2}";

        private string name;

        private string location;

        private IList<IRecipe> recipes;

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(String.Format(NullOrEmptyErrorMessage, "Name"));
                }

                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(String.Format(NullOrEmptyErrorMessage, "Location"));
                }

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get
            {
                return this.recipes;
            }
        }

        public void AddRecipe(IRecipe recipe)
        {
            this.recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            return String.Format(MenuHeader, this.Name, this.Location, "No recipes... yet");
        }

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.recipes = new System.Collections.Generic.List<IRecipe>();
        }
    }
}
