using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Models
{    
    public class UserRepository : IUserRepository
    {
        private readonly Dictionary<int, User> _data = new();
        public UserRepository()
        {
            _data.Add(1, new User(1, "Yusuf Özgün"));
            _data.Add(2, new User(2, "Luc Vervoort"));
            _data.Add(3, new User(3, "Lionel Messi"));
            _data.Add(4, new User(4, "Cristiano Ronaldo"));
            _data.Add(5, new User(5, "Ronaldinho"));
        }
        public bool ExistsUser(int id) 
        { 
            if (_data.ContainsKey(id)) 
                return true; 
            else 
                return false; }
        public IEnumerable<User> GetAll()
        {
            return _data.Values;
        }
        public User GetUser(int id)
        {
            if (_data.ContainsKey(id))
                return _data[id];
            else
                throw new UserException("User does not exist");
        }
        public void AddUser(User user)
        {
            if (_data.ContainsKey(user.Id))
                _data.Add(user.Id, user);
            else
                throw new UserException("User already added");
        }
        public void RemoveUser(User user)
        {
            if (_data.ContainsKey(user.Id))
                _data.Remove(user.Id);
            else
                throw new UserException("User doesn't exist");
        }
        public void UpdateUser(User user)
        {
            if (_data.ContainsKey(user.Id)) _data[user.Id] = user;
            else
                throw new UserException("User doesn't exist");
        }
    }
}