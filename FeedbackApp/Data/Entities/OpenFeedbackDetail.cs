using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("chi_tiet_khao_sat_mo")]
    public class OpenFeedbackDetail
    {
        [Required]
        [Column("ma_cau_hoi_mo")]
        public short OpenQuestionId { get; set; }
        [Required]
        [Column("ma_phan_hoi")]
        public long FeedbackId { get; set; }
        public string? Conttent { get; set; }

        public OpenQuestion OpenQuestion { get; set; }
        public Feedback Feedback { get; set; }
    }
}
