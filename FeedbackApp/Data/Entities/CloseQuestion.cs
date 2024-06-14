using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("cau_hoi_dong")]
    public class CloseQuestion
    {
        [Key]
        [Column("ma_cau_hoi_dong")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [Required]
        [Column("ten_cau_hoi_dong")]
        public string Name { get; set; }

        [Required]
        [Column("trang_thai")]
        public bool Status { get; set; }

        [Required]
        [Column("thu_tu")]
        public short OrdinalNumber { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("ma_danh_muc_cau_hoi_dong")]
        public string CloseQuestionCategoryId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("ma_loai_muc_do_danh_gia")]
        public string ScoreTypeId { get; set; }

        public CloseQuestionCategory CloseQuestionCategory { get; set; }
        public ScoreType ScoreType { get; set; }

        public List<CloseFeedbackQuestion> CloseFeedbackQuestions { get; set; }
        public List<CloseFeedbackDetail> CloseFeedbackDetails { get; set; }
    }
}
