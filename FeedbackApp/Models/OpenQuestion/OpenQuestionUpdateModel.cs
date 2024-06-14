using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.OpenQuestion
{
    public class OpenQuestionUpdateModel
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public short OrdinalNumber { get; set; }
        public List<string> FeedTypeIds { get; set; }
    }
}
