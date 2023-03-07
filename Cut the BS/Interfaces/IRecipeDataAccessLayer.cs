using Cut_the_BS.Models;


namespace Cut_the_BS.Interfaces
{
    public interface IRecipeDataAccessLayer
    {
        IEnumerable<Recipe> GetRecipes();
        void AddRecipe(Recipe recipe);

        void RemoveRecipe(int? id);

        Recipe GetRecipe(int? id);

        void EditRecipe(Recipe recipe);

        IEnumerable<Recipe> Filter(string ingrdiants);

    }
}
