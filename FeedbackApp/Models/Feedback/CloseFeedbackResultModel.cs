using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class CloseFeedbackResultModel
    {
        public short CloseQuestionId { get; set; }
        public string CloseQuestionName { get; set; }
        public string ScoreTypeId { get; set; }
        public short ScoreId { get; set; }
        public short OrdinalNumber { get; set; }
    }
}
