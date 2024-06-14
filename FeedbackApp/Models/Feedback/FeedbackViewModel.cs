using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class FeedbackViewModel
    {
        public long Id { get; set; }
        public string FeebackTypeId { get; set; }
        public DateTime FeedbackDate { get; set; }
        public bool IsInsurance { get; set; }
        public short DayNumber { get; set; }
    }
}
