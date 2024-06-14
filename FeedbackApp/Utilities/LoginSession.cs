using FeedbackApp.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Utilities
{
    public class LoginSession
    {
        public static bool Status { get; set; } = false;
        public static EmployeeViewModel MyAccount { get; set; } = null;
    }
}
