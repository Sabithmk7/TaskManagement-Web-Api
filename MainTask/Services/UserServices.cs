using MainTask.Models;

namespace MainTask.Services
{
    public interface IUser
    {
        void Register(User user);
        User Login(Login user);
        List<User> GetUsers();
    }
    public class UserServices: IUser
    {
        List<User> users = new List<User>() 
        {
            new User{Id=1,UserName="admin",Password="admin",Role="admin"},
            new User{Id=2,UserName="user1",Password="user1",Role="user1"}
        };

        public void Register(User  user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
        }

       public User Login(Login user)
        {
            var us=users.FirstOrDefault(x=>x.UserName==user.UserName && x.Password==user.Password);
            return us;
        }
        public List<User> GetUsers()
        {
            return users;
        }
    }
}
