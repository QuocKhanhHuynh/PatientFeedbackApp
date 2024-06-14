using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Employee
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
