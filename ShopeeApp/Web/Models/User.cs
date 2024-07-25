using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; } = 1;
        [Required]
        public string FullName {  get; set; }
        [Required]
        public byte Gender { get; set; }
        public string PhoneNumber {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Avatar {  get; set; }
        public byte Status { get; set; } = 1;
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}
