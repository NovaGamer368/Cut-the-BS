using Cut_the_BS.Models;

namespace Cut_the_BS.Interfaces
{
    public interface IUserDataAccessLayer
    {
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        User GetUser(int? id);
        void EditUser(User user);
    }
}
