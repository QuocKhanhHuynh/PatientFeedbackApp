using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Employee
{
    public class EmployeePasswordUpdateModel
    {
        public string Username { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
