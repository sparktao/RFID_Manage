using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Org.Tao.DB.Model
{
    [Table("tag_info")]
    public class TagInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SeqNum { get; set; }

        [Column("tag_name", TypeName ="varchar(50)")]
        [Required, MaxLength(50)]
        public string TagName { get; set; }

        [Column("fish_classname", TypeName = "varchar(100)")]
        [Required, MaxLength(100)]
        public String FishClassName { get; set; }

        [Column("fish_weight", TypeName = "decimal(5, 2)")]
        public long FishWeight { get; set; }

        [Column("fish_height", TypeName = "decimal(5, 2)")]
        public long FishHeight { get; set; }


    }
}
