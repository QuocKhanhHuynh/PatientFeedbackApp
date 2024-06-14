using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Score
{
    public class ScoreCreateModel
    {
        public string ScoreTypeId { get; set; }
        public short Number { get; set; }
        public string Name { get; set; }
    }
}
