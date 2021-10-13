using System;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Assignment1.Data;



namespace Assignment1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string Password);
        void RegisterUser(User user);
        
    }
}