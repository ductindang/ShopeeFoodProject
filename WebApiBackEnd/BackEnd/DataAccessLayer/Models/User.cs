using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; } = 1;
        [Required]
        public string FullName { get; set; }
        [Required]
        public byte Gender { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? Avatar { get; set; }
        public byte Status { get; set; } = 1;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsEmailVerified {  get; set; }
        public string? VerificationEmailToken {  get; set; }
        public DateTime? VerificationEmailTokenExpiry {  get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiry { get; set; }
    }
}
