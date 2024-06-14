using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class FeedbackDetailViewModel
    {
        public Dictionary<CloseQuestionCategoryLoadViewModel, List<CloseFeedbackResultModel>> CloseFeedbacks { get; set; }
        public List<OpenFeedbackResultModel> OpenFeedbacks { get; set; }
    }
}
