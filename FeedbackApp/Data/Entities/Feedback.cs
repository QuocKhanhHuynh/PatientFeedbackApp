using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("phan_hoi")]
    public class Feedback
    {
        [Key]
        [Column("ma_phan_hoi")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("thoi_gian_thuc_hien")]
        public DateTimeOffset Date { get; set; }

        [MaxLength(11)]
        [Column("so_dien_thoai")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("su_dung_bhyt")]
        public bool IsInsurance { get; set; }

        [Required]
        [Column("so_ngay_dieu_tri")]
        public short DayNumber { get; set; }

        [Column("ma_loai_khao_sat")]
        [MaxLength(10)]
        public string FeebackTypeId { get; set; }

        public Client Client { get; set; }
        public FeedbackType FeedbackType { get; set; }
        public List<CloseFeedbackDetail> CloseFeedbackDetails { get; set; }
        public List<OpenFeedbackDetail> OpenFeedbackDetail { get; set; }
    }
}