using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("Contacts", Schema = "system")]
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        [NotMapped]
        public string Name => $"{FirstName} {LastName}";

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool Deleted { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }

        public string? MachineInfo { get; set; }
    }
}
