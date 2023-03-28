using LoanManagementSystem.Models;

namespace LoanManagementSystem.Sessions
{
    public class AccountService : IAccountServices
    {
        private List<Account> _accounts;

        public AccountService() 
        {
            _accounts = new List<Account>()
            {
                new Account()
                {
                    userName = "chinmay",
                    passWord = "Chinmay29%"
                },
                 new Account()
                {
                    userName = "vinay",
                    passWord = "Vinay17%"
                }
            };
        }

        public Account Login(string username, string password)
        {
            return _accounts.SingleOrDefault(x=>x.userName==username && x.passWord==password);
        }
    }
}
