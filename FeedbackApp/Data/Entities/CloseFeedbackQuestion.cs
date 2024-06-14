using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("cau_hoi_khao_sat_dong")]
    public class CloseFeedbackQuestion
    {
        [Required]
        [MaxLength(10)]
        [Column("ma_loai_khao_sat")]
        public string FeedbackTypeId { get; set; }
        /*
        [Required]
        [MaxLength(10)]
        [Column("ma_danh_muc_cau_hoi_dong")]
        public string CloseQuestionCategoryId { get; set; }
        */
        [Required]
        [Column("ma_cau_hoi_dong")]
        public short CloseQuestionId { get; set; }

        public FeedbackType FeedbackType { get; set; }
        public CloseQuestion CloseQuestion { get; set; }

    }
}
