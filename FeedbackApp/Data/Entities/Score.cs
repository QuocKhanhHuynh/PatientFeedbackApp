using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("muc_do")]
    public class Score
    {
        [Column("ma_muc_do_diem")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [Required]
        [Column("ten_muc_do_diem")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("muc_diem_so")]
        public short Number { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("ma_loai_muc_do_danh_gia")]
        public string ScoreTypeId { get; set; }
        public ScoreType ScoreType { get; set; }
        public List<CloseFeedbackDetail> CloseFeedbackDetails { get; set; }
    }
}
