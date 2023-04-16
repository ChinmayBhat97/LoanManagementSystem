using LoanManagementSystem.Models;
using LoanManagementSystem.Sessions;

namespace LoanManagementSystem.Sessions
{
    public class AccountService : IAccountServices
    {
        private readonly Context _context;

        public AccountService(Context context)
        {
            _context = context;
        }

       

        public User Login(string username, string password)
        {
            return _context.Users.SingleOrDefault(x=>x.userName==username && x.passWord==password);
        }
    }
}


//private List<Account> _accounts;

//public AccountService()
//{
//    _accounts = new List<Account>()
//            {
//                new Account()
//                {
//                    userName = "chinmay",
//                    passWord = "Chinmay29%"
//                },
//                 new Account()
//                {
//                    userName = "vinay",
//                    passWord = "Vinay17%"
//                }
//            };
//}

//public Account Login(string username, string password)
//{
//    return _accounts.SingleOrDefault(x => x.userName==username && x.passWord==password);
//}
