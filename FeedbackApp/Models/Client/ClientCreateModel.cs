using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Models.Client
{
    public class ClientCreateModel
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public short Age { get; set; }
        public short Distance { get; set; }
    }
}
