using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("loai_khao_sat")]
    public class FeedbackType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ma_loai_khao_sat")]
        [MaxLength(10)]
        public string Id { get; set; }

        [Required]
        [Column("ten_loai_khao_sat")]
        public string Name { get; set; }

        public List<CloseFeedbackQuestion> CloseFeedbackQuestions { get; set; }
        public List<OpenFeedbackQuestion> OpenFeedbackQuestions { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
