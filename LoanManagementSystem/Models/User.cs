using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [DisplayName("User Name")]
        public string userName { get; set; }
        [DisplayName("Password")]
        public string passWord { get; set; }
        [DisplayName("Email ID")]
        //[Remote(action: "IsEmailExist", controller:"Users", ErrorMessage = "EmailId already exists.")]
        public string emailID { get; set; }
        [DisplayName("Role")]
        public virtual int roleId { get; set; }
        [ForeignKey("roleId")]
        public virtual Roles Roles { get; set; }
        [DisplayName("Active Status")]
        public bool activeStatus { get; set; }
    }
}
