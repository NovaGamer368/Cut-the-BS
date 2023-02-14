using Cut_the_BS.Models;
using Cut_the_BS.Interfaces;

namespace Cut_the_BS.Data
{
    public class UserListDAL : IUserDataAccessLayer
    {
        private AppDbContext db;
        public UserListDAL(AppDbContext db)
        {   
            this.db = db;
        }
        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
