﻿using LoanManagementSystem.Models;

namespace LoanManagementSystem.Sessions
{
    public interface IAccountServices
    {
        public Account Login (string username, string password);

        //public User Login (string username, string password, string email);
    }
}
