using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("loai_muc_do_danh_gia")]
    public class ScoreType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ma_loai_muc_do_danh_gia")]
        [MaxLength(10)]
        public string Id { get; set; }

        [Required]
        [Column("ten_loai_muc_do_danh_gia")]
        public string Name { get; set; }

        public List<Score> Scores { get; set; }
        public List<CloseQuestion> CloseQuestions { get; set; }
    }
}
