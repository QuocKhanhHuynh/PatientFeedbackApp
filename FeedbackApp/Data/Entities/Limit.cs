using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("quyen")]
    public class Limit
    {
        [Column("ten_dang_nhap")]
        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Column("ma_hoat_dong")]
        [Required]
        public short FunctionId { get; set; }

        public Employee Employee { get; set; }
        public Function Function { get; set; }
    }
}
