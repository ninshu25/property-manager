using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("UsageLogs", Schema = "log")]
    public class UsageLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(150)]
        public string MethodName { get; set; }

        [Required]
        [StringLength(150)]
        public string MachineInfo { get; set; }

        [Required]
        public DateTime CreatedDateTime { get; set; }
    }
}
