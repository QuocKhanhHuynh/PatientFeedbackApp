using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("benh_nhan")]
    public class Client
    {
        [Key]
        [MaxLength(11)]
        [Column("so_dien_thoai")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("ho_ten")]
        public string FullName { get; set; }

        [Required]
        [Column("gioi_tinh")]
        [MaxLength(3)]
        public string Gender { get; set; }

        [Required]
        [Column("tuoi")]
        public short Age { get; set; }

        [Required]
        [Column("khoang_cach")]
        public short Distance { get; set;}

        [Column("su_dung_bhyt")]
        public bool? IsInsurance { get; set; }

        [Column("so_ngay_dieu_tri")]
        public short? DayNumber { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}
