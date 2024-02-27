
using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("Properties", Schema = "system")]
    public class Property
    {
        [Key]
        public Guid Id { get; set; }

        public PropertyType PropertyTypeId { get; set; }

        public string Name { get; set; }

        public string StreetName { get; set; }

        public string HouseName { get; set; }

        public string HouseNumber { get; set; }

        public string PostCode { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public float Price { get; set; }

        public bool Deleted { get; set; }

        public bool Selling {  get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public string? MachineInfo { get; set; }
    }
}
