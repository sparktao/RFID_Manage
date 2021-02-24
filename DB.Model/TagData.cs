using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Org.Tao.DB.Model
{
    [Table("tag_data")]
    public class TagData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TagDataID { get; set; }

        [Column("terminal_name", TypeName = "varchar(50)")]
        public String TerminalName { get; set; }

        [Column("site_name", TypeName = "varchar(50)")]
        public String SiteName { get; set; }

        [Column("record_datetime")]
        public DateTime RecordDateTime { get; set; }

        [Column("tag_name", TypeName = "varchar(50)")]
        [Required, MaxLength(50)]
        public String TagName { get; set; }

        [Column("flag_column1", TypeName = "varchar(50)")]
        public String FlagColumn1 { get; set; }

        [Column("flag_column2", TypeName = "varchar(50)")]
        public String FlagColumn2 { get; set; }

    }
}
