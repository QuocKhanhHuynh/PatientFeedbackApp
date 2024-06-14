using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Feedback
{
    public class FeedbackDetailStatisticsModel
    {
        public string CloseQuestionCategoryId { get; set; }
        public short CloseQuestionId { get; set; }
        public string CloseQuestionName { get; set; }
        public short CloseQuestionNumber { get; set; }
        public string ScoreTypeId { get; set; }
        public List<ScoreStatisticsModel> ScoreStatisticsModels { get; set; }
        public long FeedbackTotals { get; set; }
        public long AvergraveScore { get; set; }
    }
}
