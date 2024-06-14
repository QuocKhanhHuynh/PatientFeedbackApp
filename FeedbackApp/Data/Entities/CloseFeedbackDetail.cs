using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("chi_tiet_khao_sat_dong")]
    public class CloseFeedbackDetail
    {
        [Required]
        [Column("ma_cau_hoi_dong")]
        public short CloseQuestionId { get; set; }
        [Required]
        [Column("ma_phan_hoi")]
        public long FeedbackId { get; set; }
        [Required]
        [Column("ma_muc_do_diem")]
        public short ScoreId { get; set; }

        public CloseQuestion CloseQuestion { get; set; }
        public Feedback Feedback { get; set; }
        public Score Score { get; set; }
    }
}
