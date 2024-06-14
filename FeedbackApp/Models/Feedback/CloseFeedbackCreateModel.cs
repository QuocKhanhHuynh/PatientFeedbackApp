using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class CloseFeedbackCreateModel
    {
        public short CloseQuestionId { get; set; }
        public short ScoreId { get; set; }
    }
}
