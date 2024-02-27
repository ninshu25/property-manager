using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("Log", Schema = "log")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(150)]
        public string ProcessName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string ClassName { get; set; }

        [Required]
        [StringLength(150)]
        public string MethodName { get; set; }

        [Required]
        public int LineNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Message { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string InnerMessage { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string FullMessage { get; set; }

        [Required]
        public LogType LogType { get; set; }

        [Required]
        [StringLength(150)]
        public string MachineInfo { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }
    }
}
