using FeedbackApp.Models.Client;
using FeedbackApp.Models.Employee;
using FeedbackApp.Models.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Utilities
{
    public class ClientLoginSession
    {
        public static short CategoryIndex { get; set; } = 0;
        public static FeedbackLoadViewModel FeedbackLoad { get; set; } = null;
        public static bool Status { get; set; } = false;
        public static ClientViewModel ClientAccount { get; set; } = null;
        public static FeedbackCreateModel FeedbackResult { get; set; } = null;
    }
}
