using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class OpenFeedbackViewModel
    {
        public short OpenQuestionId { get; set; }
        public string OpenQuestionName { get; set; }
        public short OrdinalNumber { get; set; }
    }
}
