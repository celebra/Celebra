using Celebra.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Celebra.BL.Controller
{
    public class UserController
    {
        public User User { get; }

        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO add realization...
            }
        }
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
        public UserController(string userName, string genderName, DateTime birdthDay, double weight, double height)
        {
            // TODO Check
            var gender = new Gender(genderName);
            User = new User(userName, gender, birdthDay, weight, height);
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
