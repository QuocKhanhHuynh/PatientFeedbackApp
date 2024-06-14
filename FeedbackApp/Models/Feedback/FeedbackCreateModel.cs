using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class FeedbackCreateModel
    {
        public string FeedbackTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsInsurance { get; set; }
        public short DayNumber { get; set; }
        public List<CloseFeedbackCreateModel> CloseFeedbacks { get; set; }
        public List<OpenFeedbackCreateModel> OpenFeedbacks { get; set; } 
    }
}
