using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Score
{
    public class ScoreViewModel
    {
        public short Id { get; set; }
        public string ScoreTypeId { get; set; }
        public string Name { get; set; }
        public short Number { get; set; }
    }
}
