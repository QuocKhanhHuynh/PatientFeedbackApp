using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class OpenFeedbackResultModel
    {
        public string OpenQuestionName { get; set; }
        public string Content { get; set; }
        public short OrdinalNumber { get; set; }
    }
}
