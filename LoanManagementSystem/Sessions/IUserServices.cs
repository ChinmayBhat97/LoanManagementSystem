using LoanManagementSystem.Models;

namespace LoanManagementSystem.Sessions
{
    public interface IUserServices
    {
        public User Login(string uName, string psswrd);
    }
}
