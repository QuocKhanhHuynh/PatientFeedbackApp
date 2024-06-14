using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("cau_hoi_khao_sat_mo")]
    public class OpenFeedbackQuestion
    {
        [Required]
        [MaxLength(10)]
        [Column("ma_loai_khao_sat")]
        public string FeedbackTypeId { get; set; }

        [Required]
        [Column("ma_cau_hoi_dong")]
        public short OpenQuestionId { get; set; }

        public FeedbackType FeedbackType { get; set; }
        public OpenQuestion OpenQuestion { get; set; }
    }
}
