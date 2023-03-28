using LoanManagementSystem.Models;

namespace LoanManagementSystem.Sessions
{
    public class UserService
    {
        private User usr = new User();

        
        public UserService(string usrName,string passwrd)
        {
            usrName= usr.userName;
            passwrd=usr.passWord;
        }

        //public User Login(string uName, string psswrd)
        //{
        //    uName=usr.userName;
        //    psswrd=usr.passWord;
        //    return usr(x => x.userName==uName && x.passWord==psswrd);
        //}
    }
}
