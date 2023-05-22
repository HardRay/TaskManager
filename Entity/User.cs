using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int Id { get; set; }
        [Required]
        [Column("email")]
        public string? Email { get; set; }
        [Required]
        [Column("user_password")]
        public string? Password { get; set; }
        [Column("first_name")]
        public string? FirstName { get; set; }
        [Column("last_name")]
        public string? LastName { get; set; }
        [Column("middle_name")]
        public string? MiddleName { get; set; }
        [DefaultValue(false)]
        [Column("active")]
        public bool Active { get; set; }
    }
}
