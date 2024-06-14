using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("cau_hoi_mo")]
    public class OpenQuestion
    {
        [Key]
        [Column("ma_cau_hoi_mo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [Required]
        [Column("ten_cau_hoi_mo")]
        public string Name { get; set; }

        [Required]
        [Column("trang_thai")]
        public bool Status { get; set; }

        [Required]
        [Column("thu_tu")]
        public short OrdinalNumber { get; set; }

        public List<OpenFeedbackQuestion> OpenFeedbackQuestions { get; set; }
        public List<OpenFeedbackDetail> OpenFeedbackDetail { get; set; }
    }
}
