using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class User
    {
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DoB { get; set; }
        public string? Status { get; set; }
        public int? RoleId { get; set; }
        public string? Gender { get; set; }
        public string? UserImg { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
