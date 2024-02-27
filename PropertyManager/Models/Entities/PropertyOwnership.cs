using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("PropertyOwnerships", Schema = "system")]
    public class PropertyOwnership
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Contact))]
        public Guid ContactId { get; set; }

        [Required]
        [ForeignKey(nameof(Property))]
        public Guid PropertyId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AskingPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PriceAcquisition { get; set; }

        public bool Deleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EffectiveFrom { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EffectiveTill { get; set; }

        public string? MachineInfo { get; set; }
    }
}
