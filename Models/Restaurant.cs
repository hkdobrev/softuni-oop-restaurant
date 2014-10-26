namespace RestaurantManager.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using RestaurantManager.Interfaces;

    public class Restaurant : IRestaurant
    {
        private const string NullOrEmptyErrorMessage = "The {0} is required.";

        private const string UnsupportedType = "Type {0} is not supported.";

        private const string MenuHeader = "***** {0} - {1} *****";

        private const string MenuGroupHeading = "~~~~~ {0} ~~~~~";

        private readonly static Dictionary <Type, string> types = new Dictionary<Type, string>{
            {typeof (Drink), "Drinks"},
            {typeof (Salad), "Salads"},
            {typeof (MainCourse), "Main Courses"},
            {typeof (Dessert), "Desserts"}
        };

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
            return GetMenuHeader() + "\n" + GetMenuRecipes();
        }

        private string GetMenuHeader()
        {
            return String.Format(MenuHeader, this.Name, this.Location);
        }

        private string GetMenuRecipes()
        {
            if (this.recipes.Count == 0)
            {
                return "No recipes... yet";
            }

            var recipeGroups = this.recipes
                .GroupBy (u => u.GetType())
                .Select(grp => grp.ToList())
                .ToList();

            List<string> result = new List<string>();

            foreach (var recipeGroup in recipeGroups)
            {
                IEnumerator<IRecipe> recipeEnumerator = recipeGroup.GetEnumerator();
                recipeEnumerator.MoveNext();
                Recipe firstRecipe = (Recipe) recipeEnumerator.Current;
                result.Add(String.Format(
                    MenuGroupHeading,
                    Restaurant.GetMenuGroupName(firstRecipe.GetType()).ToUpper()
                ));

                foreach (var recipe in recipeGroup)
                {
                    result.Add(recipe.ToString());
                }
            }

            return String.Join ("\n", result);
        }

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.recipes = new List<IRecipe>();
        }

        private static string GetMenuGroupName(Type type)
        {
            if (!Restaurant.types.ContainsKey(type))
            {
                throw new ArgumentException(String.Format(UnsupportedType, type));
            }

            return Restaurant.types[type];
        }
    }
}
