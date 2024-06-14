using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Data.Entities
{
    [Table("hoat_dong")]
    public class Function
    {
        [Key]
        [Column("ma_hoat_dong")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [Required]
        [Column("ten_hoat_dong")]
        [MaxLength(60)]
        public string Name { get; set; }

        public List<Limit> Limits { get; set; }
    }
}
