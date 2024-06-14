using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.CloseQuestion
{
    public class CloseQuestionViewModel
    {
        public string CloseQuestionCategoryId { get; set; }
        public short Id { get; set; }
        public string Name { get; set; }
        public string ScoreTypeId { get; set; }
        public short OrdinalNumber { get; set; }
        public bool Status { get; set; }
        public List<string> FeedbackTypeIds { get; set; }
    }
}
