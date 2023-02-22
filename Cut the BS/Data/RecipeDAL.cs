using Cut_the_BS.Models;
using Cut_the_BS.Interfaces;

namespace Cut_the_BS.Data
{
    public class RecipeDAL : IUserDataAccessLayer
    {
        private AppDbContext db;
        public RecipeDAL(AppDbContext db)
        {   
            this.db = db;
        }
        public void AddRecipe(Recipe recipe)
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
        }

        public void EditRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
