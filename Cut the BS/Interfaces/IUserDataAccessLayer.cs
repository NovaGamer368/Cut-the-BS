using Cut_the_BS.Models;

namespace Cut_the_BS.Interfaces
{
    public interface IUserDataAccessLayer
    {
        IEnumerable<Recipe> GetRecipes();
        void AddRecipe(Recipe recipe);
        Recipe GetRecipe(int? id);
        void EditRecipe(Recipe recipe);
    }
}
