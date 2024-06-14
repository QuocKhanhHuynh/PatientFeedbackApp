using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Score
{
    public class ScoreUpdateModel
    {
        public string ScoreTypeId { get; set; }
        public short Id { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }
    }
}
