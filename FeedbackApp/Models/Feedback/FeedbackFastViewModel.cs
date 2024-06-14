using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class FeedbackFastViewModel
    {
        public long Id { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string FeebackTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public short Age { get; set; }
        public short Distance { get; set; }
        public bool IsInsurance { get; set; }
        public short DayNumber { get; set; }
    }
}
