using GymAttendanceSystem.Models;

namespace GymAttendanceSystem.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetByUsername(string username);
        User? ValidateUser(string username, string password);
    }

    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        private static int _nextId = 1;

        public void Add(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public User? GetByUsername(string username) =>
            _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        public User? ValidateUser(string username, string password) =>
            _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
    }
}