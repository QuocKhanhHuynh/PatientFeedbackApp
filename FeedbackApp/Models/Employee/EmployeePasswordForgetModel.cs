using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Employee
{
    public class EmployeePasswordForgetModel
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string newPassword { get; set; }
    }
}
