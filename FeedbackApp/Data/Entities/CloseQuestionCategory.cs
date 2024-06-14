using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("danh_muc_cau_hoi_dong")]
    public class CloseQuestionCategory
    {
        [Key]
        [Column("ma_danh_muc_cau_hoi_dong")]
        [MaxLength(10)]
        public string Id { get; set; }

        [Required]
        [Column("ten_danh_muc_cau_hoi_dong")]
        public string Name { get; set; }

        [Required]
        [Column("trang_thai")]
        public bool Status { get; set; }

        public List<CloseQuestion> CloseQuestions { get; set; }
    }
}
