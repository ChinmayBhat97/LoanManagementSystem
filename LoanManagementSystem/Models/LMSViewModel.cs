namespace LoanManagementSystem.Models
{
    public class LMSViewModel
    {
        public IEnumerable<User> User { get; set; }

        public IEnumerable<Roles> Roles { get; set; }

        public IEnumerable<States> States { get; set; }

        public IEnumerable<Accounts> Accounts { get; set; }
    }
}
