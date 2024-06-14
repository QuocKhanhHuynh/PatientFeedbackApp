using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("nhan_vien")]
    public class Employee
    {
        [Key]
        [Column("ten_dang_nhap")]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [Column("mat_khau")]
        [MaxLength(60)]
        public string Password { get; set; }

        [Required]
        [Column("ho_ten")]
        [MaxLength(30)]
        public string Fullname { get; set; }

        [Required]
        [Column("so_dien_thoai")]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("thu_dien_tu")]
        [MaxLength(50)]
        public string Email { get; set; }

        public List<Limit> Limits { get; set; }
    }
}
