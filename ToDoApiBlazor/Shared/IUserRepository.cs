using ToDoApiBlazor.Shared;

namespace EenVoudigeToDoApi.Models
{
    //CRUD
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(int id);
        IEnumerable<User> GetAll();
        void RemoveUser(User user);
        void UpdateUser(User user);
        bool ExistsUser(int id);
    }
}
