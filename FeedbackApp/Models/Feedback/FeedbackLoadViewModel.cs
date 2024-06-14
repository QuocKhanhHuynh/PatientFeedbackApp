using FeedbackApp.Models.CloseQuestionCategory;
using FeedbackApp.Models.FeedbackType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class FeedbackLoadViewModel
    {
        public Dictionary<CloseQuestionCategoryLoadViewModel, List<CloseFeedbackViewModel>> CloseFeedbacks { get; set; }
        public List<OpenFeedbackViewModel> OpenFeedbacks { get; set; }
    }
}
