using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.FeedbackType
{
    public class FeedbackTypeCreateModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
