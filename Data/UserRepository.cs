using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uas_apk.Models;

namespace uas_apk.Data
{
    public static class UserRepository
    {
        private static List<User> _users = new List<User>();
        private const string UsersFileName = "users.json";

        public static User CurrentLoggedInUser { get; private set; }

        public static async Task LoadUsersAsync()
        {
            _users = await DataService.LoadFromJsonAsync<List<User>>(UsersFileName);
        }

        public static async Task<bool> RegisterUser(string name, string email, string password)
        {
            if (_users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            var newUser = new User { Name = name, Email = email, Password = password };
            _users.Add(newUser);

            await DataService.SaveToJsonAsync(_users, UsersFileName);
            return true;
        }

        public static bool LoginUser(string email, string password)
        {
            var user = _users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (user != null)
            {
                CurrentLoggedInUser = user;
                return true;
            }

            return false;
        }

        public static void LogoutUser()
        {
            CurrentLoggedInUser = null;
        }
    }
}
