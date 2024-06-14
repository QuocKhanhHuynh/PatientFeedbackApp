using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class OpenFeedbackCreateModel
    {
        public short OpenQuestionId { get; set; }
        public string Content { get; set; }
    }
}
