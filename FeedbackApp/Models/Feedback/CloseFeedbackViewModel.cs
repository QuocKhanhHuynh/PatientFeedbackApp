using FeedbackApp.Models.ScoreType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class CloseFeedbackViewModel
    {
        public short CloseQuestionId { get; set; }
        public string CloseQuestionName { get; set; }
        public string ScoreTypeId { get; set; }
        public short OrdinalNumber {  get; set; }
    }
}
