using Cut_the_BS.Interfaces;
using Cut_the_BS.Models;

namespace Cut_the_BS.Data
{
    public class RecipeListDAL : IRecipeDataAccessLayer
    {

        private Cut_the_BSContext db;

        public RecipeListDAL(Cut_the_BSContext indb)
        {
            db = indb;
        }

        public void AddRecipe(Recipe recipe)
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
        }

        public void EditRecipe(Recipe recipe)
        {
            db.Recipes.Update(recipe);
            db.SaveChanges();
        }

        public Recipe GetRecipe(int? id)
        {
            return db.Recipes.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return db.Recipes.OrderBy(r => r.Title).ToList();
        }

        public void RemoveRecipe(int? id)
        {
            Recipe found = GetRecipe(id);
            db.Recipes.Remove(found);
            db.SaveChanges();
        }
    }
}
